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

        public async override Task<DonationDTO> Update(string id, DonationUpdateRequest request)
        {
            var entity = await _context.Donations.FindAsync(id);

            entity.PropertyChanged += NotifyUser;

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<DonationDTO>(entity);
        }

        public async void NotifyUser(object sender, EventArgs e)
        {
            var donation = (Donation)sender;

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
    }
}
