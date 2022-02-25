using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Badge;
using Vivel.Model.Requests.Donation;
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
        public override Task<ActionResult<UserDTO>> Insert([FromBody] object request)
        {
            return base.Insert(request);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<UserDetailsDTO>> Details(string id)
        {
            var entity = await _userService.Details(id);

            if (entity != null)
            {
                return new OkObjectResult(entity);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{id}/donations")]
        public async Task<PagedResult<DonationDTO>> Donations(string id, [FromQuery] DonationSearchRequest request)
        {
            return await _userService.Donations(id, request);
        }

        [HttpGet("{userId}/donation/{donationId}")]
        public async Task<ActionResult<DonationDTO>> Donations(string userId, string donationId)
        {
            var entity = await _userService.Donation(userId, donationId);
            if (entity != null)
            {
                return new OkObjectResult(entity);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{id}/notifications")]
        public async Task<PagedResult<NotificationDTO>> Notifications(string id, [FromQuery] NotificationSearchRequest request)
        {
            return await _userService.Notifications(id, request);
        }

        [HttpGet("{id}/badges")]
        public async Task<PagedResult<BadgeDTO>> Badges(string id, [FromQuery] BadgeSearchRequest request)
        {
            return await _userService.Badges(id, request);
        }
    }
}
