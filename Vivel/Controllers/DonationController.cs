using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;

namespace Vivel.Controllers
{
    public class DonationController : BaseCRUDController<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
        public DonationController(IDonationService service) : base(service)
        {
        }

        [Authorize(Roles = "admin")]
        public async override Task<PagedResult<DonationDTO>> Get([FromQuery] DonationSearchRequest request)
        {
            return await base.Get(request);
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<DonationDTO>> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "admin,user")]
        public async override Task<ActionResult<DonationDTO>> Insert([FromBody] DonationInsertRequest request)
        {
            var user = HttpContext.User;

            var userClaimValue = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAdmin = user.IsInRole("admin");
            var isUser = user.IsInRole("user");

            if (isAdmin || (isUser && userClaimValue == request.UserId))
                return await base.Insert(request);

            return Unauthorized();
        }

        [Authorize(Roles = "admin,staff")]
        public async override Task<ActionResult<DonationDTO>> Update(Guid id, [FromBody] DonationUpdateRequest request)
        {
            return await base.Update(id, request);
        }
    }
}
