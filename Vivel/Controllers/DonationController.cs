using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class DonationController : BaseCRUDController<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
        public DonationController(IDonationService service) : base(service)
        {
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async override Task<ActionResult<DonationDTO>> Insert([FromBody] DonationInsertRequest request)
        {
            var user = HttpContext.User;

            var userClaimValue = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isUser = user.IsInRole("user");

            if (isUser && userClaimValue == request.UserId)
                return await base.Insert(request);

            return Unauthorized();
        }
    }
}
