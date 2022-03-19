using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
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
            var entity = _context.Users
                .Include(x => x.BloodType)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.UserName))
            {
                entity = entity.Where(user => user.UserName.Contains(request.UserName));
            }

            if (request?.BloodType?.Count > 0)
            {
                entity = entity.Where(user => request.BloodType.Any(x => x == user.BloodType.Name));
            }

            if (request?.Verified != null)
            {
                entity = entity.Where(x => x.Verified == request.Verified);
            }

            return await entity.GetPagedAsync<User, UserDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async override Task<UserDTO> GetById(string id)
        {
            var entity = await _context.Users
                .Include(x => x.BloodType)
                .Where(x => x.UserId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<UserDetailsDTO> Details(string id)
        {
            var entity = await _context.Users
                .Include(x => x.Donations).ThenInclude(x => x.Status)
                .Include(x => x.BloodType)
                .Where(x => x.UserId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserDetailsDTO>(entity);
        }


        public async Task<PagedResult<DonationDTO>> Donations(string id, DonationSearchRequest request)
        {
            var entity = _context.Donations
                .Include(x => x.DonationReport)
                .Include(x => x.Status)
                .Include(x => x.Drive).ThenInclude(x => x.BloodType)
                .Include(x => x.Drive).ThenInclude(x => x.Hospital)
                .Where(x => x.UserId == id);

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

        public async Task<DonationDTO> Donation(string userId, string donationId)
        {
            var entities = await _context.Donations
                .Include(x => x.DonationReport)
                .Include(x => x.Status)
                .Include(x => x.Drive).ThenInclude(x => x.BloodType)
                .Include(x => x.Drive).ThenInclude(x => x.Hospital)
                .Where(x => x.UserId == userId && x.DonationId == donationId)
                .FirstOrDefaultAsync();

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

            entities = entities.OrderByDescending(x => x.CreatedAt);

            return await entities.GetPagedAsync<Notification, NotificationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<PagedResult<BadgeDTO>> Badges(string id, BadgeSearchRequest request)
        {
            return await _context.Badges.Include(x => x.PresetBadge).Where(x => x.UserId == id).GetPagedAsync<Badge, BadgeDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

    }
}
