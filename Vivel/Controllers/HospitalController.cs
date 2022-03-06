using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
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
        public HospitalController(IHospitalService service) : base(service)
        {
            _hospitalService = service;
        }

        [HttpGet("{id}/drives")]
        [Authorize(Roles = "staff,admin")]
        public async Task<ActionResult<PagedResult<DriveDTO>>> Drives(string id, [FromQuery] DriveSearchRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != null && hospitalClaimValue == id))
                return new OkObjectResult(await _hospitalService.Drives(id, request));

            return Unauthorized();
        }

        [HttpGet("{id}/report/drives")]
        [Authorize(Roles = "staff,admin")]
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
        [Authorize(Roles = "staff,admin")]
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
