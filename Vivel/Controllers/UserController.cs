using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.User;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class UserController : BaseCRUDController<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        private IUserService _user_service { get; set; }
        public UserController(IUserService service) : base(service)
        {
            _user_service = service;
        }

        [NonAction]
        public override Task<UserDTO> Insert([FromBody] object request)
        {
            return base.Insert(request);
        }

        [HttpGet("{id}/details")]
        public Task<UserDetailsDTO> Details(string id)
        {
            return _user_service.Details(id);
        }

        [HttpGet("{id}/donations")]
        public Task<List<DonationDTO>> Donations(string id)
        {
            return _user_service.Donations(id);
        }

        [HttpGet("{id}/notifications")]
        public Task<List<NotificationDTO>> Notifications(string id)
        {
            return _user_service.Notifications(id);
        }

        [HttpGet("{id}/badges")]
        public Task<List<BadgeDTO>> Badges(string id)
        {
            return _user_service.Badges(id);
        }
    }
}
