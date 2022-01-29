using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Requests.Badge;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Services
{
    public class UserService : BaseCRUDService<UserDTO, User, UserSearchRequest, object, UserUpdateRequest>, IUserService
    {
        public UserService(VivelContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<PagedResult<UserDTO>> Get(UserSearchRequest request = null)
        {
            var entity = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.UserName))
            {
                entity = entity.Where(user => user.UserName.Contains(request.UserName));
            }

            if (request?.BloodType?.Count > 0)
            {
                entity = entity.Where(user => request.BloodType.Select(x => BloodType.FromName(x, false)).Any(z => z == user.BloodType));
            }

            if (request?.Verified != null)
            {
                entity = entity.Where(x => x.Verified == request.Verified);
            }

            var users = await entity.GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<UserDTO>>(users.Results);

            return new PagedResult<UserDTO>
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = users.PageCount,
                TotalItems = users.TotalItems
            };
        }

        public async Task<UserDetailsDTO> Details(string id)
        {
            var entity = await _context.Users.Include(x => x.Donations).Where(x => x.UserId == id).FirstAsync();

            return _mapper.Map<UserDetailsDTO>(entity);
        }


        public async Task<PagedResult<DonationDTO>> Donations(string id, DonationSearchRequest request)
        {
            var entity = _context.Donations.Where(x => x.UserId == id);

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Select(x => DonationStatus.FromName(x, false)).Any(y => y == donation.Status));
            }

            var donations = await entity.GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<DonationDTO>>(donations.Results);

            return new PagedResult<DonationDTO>()
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = donations.PageCount,
                TotalItems = donations.TotalItems
            };
        }

        public async Task<DonationDTO> Donation(string userId, string donationId)
        {
            var entities = await _context.Donations.Where(x => x.UserId == userId && x.DonationId == donationId).FirstOrDefaultAsync();

            return _mapper.Map<DonationDTO>(entities);
        }

        public async Task<PagedResult<NotificationDTO>> Notifications(string id, NotificationSearchRequest request)
        {
            var entities = _context.Notifications.Where(x => x.UserId == id);

            if (request?.LinkId != null)
            {
                entities = entities.Where(x => x.LinkId == request.LinkId);
            }

            if (request?.LinkId != null && request.LinkType != null)
            {
                entities = entities.Where(x => x.LinkId == request.LinkId && x.LinkType == request.LinkType);
            }

            var notifications = await entities.GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<NotificationDTO>>(notifications.Results);

            return new PagedResult<NotificationDTO>()
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = notifications.PageCount,
                TotalItems = notifications.TotalItems
            };
        }

        public async Task<PagedResult<BadgeDTO>> Badges(string id, BadgeSearchRequest request)
        {
            var badges = await _context.Badges.Include(x => x.PresetBadge).Where(x => x.UserId == id).GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<BadgeDTO>>(badges.Results);

            return new PagedResult<BadgeDTO>()
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = badges.PageCount,
                TotalItems = badges.TotalItems
            };
        }

    }
}
