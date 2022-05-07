using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Badge;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

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

        [Authorize(Roles = "admin")]
        public async override Task<PagedResult<UserDTO>> Get([FromQuery] UserSearchRequest request)
        {
            return await base.Get(request);
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<UserDTO>> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "admin,user")]
        public async override Task<ActionResult<UserDTO>> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("user") && userId != id.ToString())
            {
                return Forbid();
            }

            return await base.Update(id, request);
        }

        [HttpGet("{id}/details")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<UserDetailsDTO>> Details(Guid id)
        {
            var userClaimValue = getUserClaim();

            if (userIsAdmin() || (userClaimValue == id))
            {
                var entity = await _userService.Details(id);

                if (entity != null)
                    return new OkObjectResult(entity);
                else
                    return new NotFoundResult();
            }

            return Unauthorized();
        }

        [HttpGet("{id}/donations")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<PagedResult<DonationDTO>>> Donations(Guid id, [FromQuery] DonationSearchRequest request)
        {
            var userClaimValue = getUserClaim();

            if (userIsAdmin() || userClaimValue == id)
                return await _userService.Donations(id, request);

            return Unauthorized();
        }

        [HttpGet("{userId}/donation/{donationId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<DonationDTO>> Donations(Guid userId, Guid donationId)
        {
            var userClaimValue = getUserClaim();

            if (userIsAdmin() || userClaimValue == userId)
            {
                var entity = await _userService.Donation(userId, donationId);

                if (entity != null)
                    return new OkObjectResult(entity);
                else
                    return new NotFoundResult();
            }

            return Unauthorized();

        }

        [HttpGet("{id}/notifications")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<PagedResult<NotificationDTO>>> Notifications(Guid id, [FromQuery] NotificationSearchRequest request)
        {
            var userClaimValue = getUserClaim();

            if (userIsAdmin() || userClaimValue == id)
                return await _userService.Notifications(id, request);

            return Unauthorized();
        }

        [HttpGet("{id}/badges")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<PagedResult<BadgeDTO>>> Badges(Guid id, [FromQuery] BadgeSearchRequest request)
        {
            var userClaimValue = getUserClaim();

            if (userIsAdmin() || userClaimValue == id)
                return await _userService.Badges(id, request);

            return Unauthorized();
        }

        private Guid getUserClaim()
        {
            return Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        private bool userIsAdmin()
        {
            return HttpContext.User.IsInRole("admin");
        }
    }
}
