﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Controllers
{
    public class HospitalController : BaseCRUDController<HospitalDTO, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IConverter _converter;
        public HospitalController(IHospitalService service, IConverter converter) : base(service)
        {
            _hospitalService = service;
            _converter = converter;
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

        public async override Task<ActionResult<HospitalDTO>> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<HospitalDTO>> Update(Guid id, [FromBody] HospitalUpsertRequest request)
        {
            return await base.Update(id, request);
        }

        [HttpGet("{id}/drives")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult<PagedResult<DriveDTO>>> Drives(Guid id, [FromQuery] DriveSearchRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != Guid.Empty && hospitalClaimValue == id))
                return new OkObjectResult(await _hospitalService.Drives(id, request));

            return Unauthorized();
        }

        [HttpGet("{id}/report/drives")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult> DrivesReport(Guid id, [FromQuery] HospitalReportDrivesRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != Guid.Empty && hospitalClaimValue == id))
            {
                var pdf = await _hospitalService.DrivesReport(id, request);

                var file = _converter.Convert(pdf);

                return File(file, "application/pdf", "drives_report");
            }

            return Unauthorized();
        }

        [HttpGet("{id}/report/litresbybloodtype")]
        [Authorize(Roles = "admin,staff")]
        public async Task<ActionResult> LitresByBloodTypeReport(Guid id, [FromQuery] HospitalReportLitresRequest request)
        {
            var hospitalClaimValue = getHospitalClaim();

            if (userIsAdmin() || (hospitalClaimValue != Guid.Empty && hospitalClaimValue == id))
            {
                var pdf = await _hospitalService.LitresByBloodTypeReport(id, request);

                var file = _converter.Convert(pdf);

                return File(file, "application/pdf", "litres_by_bloodtype_report");
            }

            return Unauthorized();
        }

        private Guid getHospitalClaim()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var hospitalClaimValue = identity.FindFirst("hospital")?.Value;

            if (hospitalClaimValue == null)
                return Guid.Empty;

            return Guid.Parse(hospitalClaimValue);
        }

        private bool userIsAdmin()
        {
            return HttpContext.User.IsInRole("admin");
        }
    }
}
