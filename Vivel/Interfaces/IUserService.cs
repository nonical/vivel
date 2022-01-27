using System.Collections.Generic;
using System.Threading.Tasks;
using Vivel.Helpers;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Badge;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Interfaces
{
    public interface IUserService : IBaseCRUDService<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        Task<UserDetailsDTO> Details(string id);
        Task<PagedResult<DonationDTO>> Donations(string id, DonationSearchRequest request);
        Task<DonationDTO> Donation(string userId, string donationId);
        Task<PagedResult<NotificationDTO>> Notifications(string id, NotificationSearchRequest request);
        Task<PagedResult<BadgeDTO>> Badges(string id, BadgeSearchRequest request);
    }
}
