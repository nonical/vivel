using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Controllers
{
    public class DriveController : BaseCRUDController<DriveDTO, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>
    {
        private readonly IDriveService _driveService;
        public DriveController(IDriveService service) : base(service)
        {
            _driveService = service;
        }

        [HttpPost]
        [Authorize(Roles = "admin,staff")]
        public async override Task<ActionResult<DriveDTO>> Insert([FromBody] DriveInsertRequest request)
        {
            var user = HttpContext.User;

            var hospitalClaimValue = user.FindFirst("hospital")?.Value;
            var isAdmin = user.IsInRole("admin");

            if (isAdmin || hospitalClaimValue == request.HospitalId)
                return await base.Insert(request);

            return Unauthorized();
        }

        [HttpGet("{id}/donations")]
        [Authorize(Roles = "admin,staff")]
        public async Task<PagedResult<DonationDTO>> Donations(string id, [FromQuery] DonationSearchRequest request)
        {
            return await _driveService.Donations(id, request);
        }

        [HttpGet("{id}/details")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<DriveDetailsDTO>> Details(string id)
        {
            var entity = await _driveService.Details(id);
            if (entity != null)
                return new OkObjectResult(entity);
            else
                return new NotFoundResult();
        }
    }
}
