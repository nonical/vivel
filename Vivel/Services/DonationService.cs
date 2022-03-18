using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;

namespace Vivel.Services
{
    public class DonationService : BaseCRUDService<DonationDTO, Donation, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>, IDonationService
    {
        private readonly INotificationService _notificationService;

        public DonationService(VivelContext context, IMapper mapper, INotificationService notificationService) : base(context, mapper)
        {
            _notificationService = notificationService;
        }

        public async override Task<PagedResult<DonationDTO>> Get(DonationSearchRequest request = null)
        {
            var entity = _context.Set<Donation>()
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.Drive).ThenInclude(x => x.BloodType)
                .Include(x => x.Drive).ThenInclude(x => x.Hospital)
                .AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Any(x => x == donation.Status.Name));
            }

            return await entity.GetPagedAsync<Donation, DonationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async override Task<DonationDTO> GetById(string id)
        {
            var entity = await _context.Donations
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.Drive).ThenInclude(x => x.BloodType)
                .Include(x => x.Drive).ThenInclude(x => x.Hospital)
                .Where(x => x.DonationId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<DonationDTO>(entity);
        }

        public async override Task<DonationDTO> Insert(DonationInsertRequest request)
        {
            var user = await _context.Users
                .Include(x => x.BloodType)
                .Include(x => x.Donations)
                .ThenInclude(x => x.Status)
                .Where(x => x.UserId == request.UserId)
                .FirstOrDefaultAsync();

            var drive = await _context.Drives
                .Include(x => x.BloodType)
                .Where(x => x.DriveId == request.DriveId)
                .FirstOrDefaultAsync();

            if (user == null || drive == null)
                return null;

            if (user.Verified == true && (user.BloodType != drive.BloodType))
                return null;

            var pendingDonationCount = user.Donations
                .Where(x => x.Status.Name == "Pending")
                .Count();

            if (pendingDonationCount != 0)
                return null;

            var lastDonationDate = user.Donations
                .Where(x => x.Status.Name == "Approved")
                .OrderByDescending(x => x.UpdatedAt)
                .Select(x => x.UpdatedAt)
                .FirstOrDefault();

            if (lastDonationDate.Value.AddMonths(3) > DateTime.Now)
                return null;

            var entity = _mapper.Map<Donation>(request);

            entity.Status = await _context.DonationStatuses.Where(x => x.Name == "Pending").FirstAsync();

            await _context.Donations.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<DonationDTO>(entity);
        }

        public async override Task<DonationDTO> Update(string id, DonationUpdateRequest request)
        {
            var entity = await _context.Donations
                .Include(x => x.Status)
                .Include(x => x.Drive)
                .Include(x => x.User)
                .Where(x => x.DonationId == id)
                .FirstOrDefaultAsync();

            if (request.Status == "Approved")
            {
                entity.Amount = 350;
            }

            entity.Status = await _context.DonationStatuses.Where(x => x.Name == request.Status).FirstAsync();

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            if (entity.Status.Name != request.Status)
                await StatusChanged(entity, request);

            return _mapper.Map<DonationDTO>(entity);
        }

        public async Task StatusChanged(Donation donation, DonationUpdateRequest request)
        {
            await NotifyUser(donation);

            if (donation.Status.Name == "Approved")
            {
                await VerifyUser(donation.UserId);
                await AddBadges(donation.UserId, donation.DriveId);
            }
            else if (donation.Status.Name == "Rejected")
            {
                await ChangeUserBloodtype(donation.UserId, request);
            }
        }

        public async Task NotifyUser(Donation donation)
        {
            var title = "";
            var content = "";

            switch (donation.Status.Name)
            {
                case "Pending":
                    title = "Successfully applied to donation.";
                    content = "Your donation is waiting to be scheduled.";
                    break;
                case "Scheduled":
                    title = "Your donation has been scheduled.";
                    content = "Tap to see details";
                    break;
                case "Approved":
                    title = "Your donation has been approved.";
                    content = "Congratulations on your donation!";
                    break;
                case "Rejected":
                    title = "Your donation has been rejected";
                    content = "Tap to see details";
                    break;
                default:
                    break;
            }

            await _notificationService.PostNotifications<Donation>(new List<string> { donation.UserId }, donation.DonationId, title, content);
        }

        public async Task AddBadges(string userId, string driveId)
        {

            var user = await _context.Users.Include(x => x.Donations).FirstAsync(x => x.UserId == userId);
            var drive = await _context.Drives.FindAsync(driveId);

            var donationCount = user.Donations.Count();
            var presetBadges = await _context.PresetBadges.ToListAsync();

            if (drive.Urgency == true)
            {
                user.Badges.Add(new Badge
                {
                    PresetBadge = presetBadges.First(x => x.Name == "Urgency"),
                    Name = "Life saver"

                });
            }

            if (user.Donations.Count() % 5 == 0)
            {
                user.Badges.Add(new Badge
                {
                    PresetBadge = presetBadges.First(x => x.Name == "Donations"),
                    Name = $"{donationCount} donations"
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task VerifyUser(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            user.Verified = true;

            await _context.SaveChangesAsync();
        }

        public async Task ChangeUserBloodtype(string userId, DonationUpdateRequest request)
        {
            var user = await _context.Users.FindAsync(userId);

            user.BloodType = await _context.BloodTypes.Where(x => x.Name == request.BloodType).FirstAsync();

            await _context.SaveChangesAsync();
        }
    }
}
