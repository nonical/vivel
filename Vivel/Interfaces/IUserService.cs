using System;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Badge;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Interfaces
{
    public interface IUserService : IBaseCRUDService<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        Task<UserDetailsDTO> Details(Guid id);
        Task<PagedResult<DonationDTO>> Donations(Guid id, DonationSearchRequest request);
        Task<DonationDTO> Donation(Guid userId, Guid donationId);
        Task<PagedResult<NotificationDTO>> Notifications(Guid id, NotificationSearchRequest request);
        Task<PagedResult<BadgeDTO>> Badges(Guid id, BadgeSearchRequest request);
    }
}
