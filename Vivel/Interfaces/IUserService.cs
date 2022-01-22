using System.Collections.Generic;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Interfaces
{
    public interface IUserService : IBaseCRUDService<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        Task<UserDetailsDTO> Details(string id);
        Task<List<DonationDTO>> Donations(string id);
        Task<DonationDTO> Donation(string userId, string donationId);
        Task<List<NotificationDTO>> Notifications(string id, NotificationSearchRequest request);
        Task<List<BadgeDTO>> Badges(string id);
    }
}
