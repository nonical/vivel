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
        private readonly IHospitalService service;
        public HospitalController(IHospitalService service) : base(service)
        {
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

        public async override Task<ActionResult<HospitalDTO>> GetById(string id)
        {
            return await base.GetById(id);
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
