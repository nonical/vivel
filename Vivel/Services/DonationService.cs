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
using Vivel.Model.Enums;
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
            var entity = _context.Set<Donation>().Include(x => x.User).AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Select(x => DonationStatus.FromName(x, false)).Any(y => y == donation.Status));
            }

            return await entity.GetPagedAsync<Donation, DonationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async override Task<DonationDTO> GetById(string id)
        {
            var entity = await _context.Donations.Include(x => x.User).Include(x => x.Drive).ThenInclude(x => x.Hospital).FirstOrDefaultAsync(x => x.DonationId == id);

            return _mapper.Map<DonationDTO>(entity);
        }

        public async override Task<DonationDTO> Insert(DonationInsertRequest request)
        {
            var pendingDonationCount = await _context.Donations.Where(x => x.UserId == request.UserId && x.Status.Name == DonationStatus.Pending.Name).CountAsync();

            if (pendingDonationCount != 0)
                return null;

            var entity = _mapper.Map<Donation>(request);

            await _context.Donations.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<DonationDTO>(entity);


        }

        public async override Task<DonationDTO> Update(string id, DonationUpdateRequest request)
        {
            var entity = await _context.Donations.Include(x => x.Drive).Include(x => x.User).FirstOrDefaultAsync(x => x.DonationId == id);

            if (entity != null)
                entity.PropertyChanged += (sender, e) => StatusChanged(sender, e, request);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<DonationDTO>(entity);
        }

        public async void StatusChanged(object sender, EventArgs e, DonationUpdateRequest request)
        {
            var donation = (Donation)sender;

            await NotifyUser(donation);

            if (donation.Status.Name == DonationStatus.Approved.Name)
            {
                await VerifyUser(donation.UserId);
                await AddBadges(donation.UserId, donation.DriveId);
            }
            else if (donation.Status.Name == DonationStatus.Rejected.Name)
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

            user.BloodType = BloodType.FromName(request.BloodType);

            await _context.SaveChangesAsync();
        }
    }
}
