using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class UserController : BaseCRUDController<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        private readonly IUserService _userService;
        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [NonAction]
        public override Task<UserDTO> Insert([FromBody] object request)
        {
            return base.Insert(request);
        }

        [HttpGet("{id}/details")]
        public Task<UserDetailsDTO> Details(string id)
        {
            return _userService.Details(id);
        }

        [HttpGet("{id}/donations")]
        public Task<List<DonationDTO>> Donations(string id)
        {
            return _userService.Donations(id);
        }

        [HttpGet("{userId}/donation/{donationId}")]
        public Task<DonationDTO> Donations(string userId, string donationId)
        {
            return _userService.Donation(userId, donationId);
        }

        [HttpGet("{id}/notifications")]
        public Task<List<NotificationDTO>> Notifications(string id, [FromQuery] NotificationSearchRequest request)
        {
            return _userService.Notifications(id, request);
        }

        [HttpGet("{id}/badges")]
        public Task<List<BadgeDTO>> Badges(string id)
        {
            return _userService.Badges(id);
        }
    }
}
