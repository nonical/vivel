using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<PagedResult<DriveDTO>> Drives(string id, [FromQuery] DriveSearchRequest request)
        {
            return await _hospitalService.Drives(id, request);
        }

        [HttpGet("{id}/report/drives")]
        public async Task<FileResult> DrivesReport(string id, [FromQuery] HospitalReportDrivesRequest request)
        {
            var pdf = await _hospitalService.DrivesReport(id, request);

            return File(pdf, "application/pdf", "drives_report");
        }

        [HttpGet("{id}/report/litresbybloodtype")]
        public async Task<FileResult> LitresByBloodTypeReport(string id, [FromQuery] HospitalReportLitresRequest request)
        {
            var pdf = await _hospitalService.LitresByBloodTypeReport(id, request);

            return File(pdf, "application/pdf", "litres_by_bloodtype_report");
        }
    }
}
