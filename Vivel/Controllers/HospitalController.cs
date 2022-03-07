using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Hospital.Reports;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class HospitalController : BaseCRUDController<HospitalDTO, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IDriveService _driveService;
        private readonly IDonationService _donationService;
        public HospitalController(IHospitalService hospitalService, IDriveService driveService, IDonationService donationService) : base(hospitalService)
        {
            _hospitalService = hospitalService;
            _driveService = driveService;
            _donationService = donationService;
        }

        [Authorize(Roles = "admin")]
        public async override Task<PagedResult<HospitalDTO>> Get([FromQuery] HospitalSearchRequest request)
        {
            return await base.Get(request);
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<HospitalDTO>> Insert([FromBody] HospitalUpsertRequest request)
        {
            return await base.Insert(request);
        }

        [Authorize(Roles = "admin,staff")]
        public async override Task<ActionResult<HospitalDTO>> GetById(string id)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == id))
                return await base.GetById(id);

            return Unauthorized();
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<HospitalDTO>> Update(string id, [FromBody] HospitalUpsertRequest request)
        {
            return await base.Update(id, request);
        }

        [HttpGet("{id}/drives")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<PagedResult<DriveDTO>>> Drives(string id, [FromQuery] DriveSearchRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == id))
                return new OkObjectResult(await _hospitalService.Drives(id, request));

            return Unauthorized();
        }

        [HttpPut("{hospitalId}/drive/{driveId}")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<DriveDTO>> Update(string hospitalId, string driveId, [FromBody] DriveUpdateRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == hospitalId))
                return new OkObjectResult(await _driveService.Update(driveId, request));

            return Unauthorized();
        }

        [HttpGet("{hospitalId}/drive/{driveId}/donations")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<PagedResult<DonationDTO>>> Donations(string hospitalId, string driveId, [FromQuery] DonationSearchRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == hospitalId))
                return new OkObjectResult(await _driveService.Donations(driveId, request));

            return Unauthorized();
        }

        [HttpGet("{hospitalId}/donation/{donationId}")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<DonationDTO>> Update(string hospitalId, string donationId, [FromBody] DonationUpdateRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == hospitalId))
                return new OkObjectResult(await _donationService.Update(donationId, request));

            return Unauthorized();
        }

        [HttpGet("{hospitalId}/drive/{driveId}/details")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<DriveDetailsDTO>> Details(string hospitalId, string driveId)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == hospitalId))
                return new OkObjectResult(await _driveService.Details(driveId));

            return Unauthorized();
        }

        [HttpGet("{id}/report/drives")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult> DrivesReport(string id, [FromQuery] HospitalReportDrivesRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == id))
            {
                var pdf = await _hospitalService.DrivesReport(id, request);

                return File(pdf, "application/pdf", "drives_report");
            }

            return Unauthorized();
        }

        [HttpGet("{id}/report/litresbybloodtype")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult> LitresByBloodTypeReport(string id, [FromQuery] HospitalReportLitresRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == id))
            {
                var pdf = await _hospitalService.LitresByBloodTypeReport(id, request);

                return File(pdf, "application/pdf", "litres_by_bloodtype_report");
            }

            return Unauthorized();
        }

        private string getHospitalClaim()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var hospitalClaimValue = identity.FindFirst("hospital")?.Value;

            return hospitalClaimValue;
        }

        private bool userIsAdmin()
        {
            return HttpContext.User.IsInRole("admin");
        }
    }
}
