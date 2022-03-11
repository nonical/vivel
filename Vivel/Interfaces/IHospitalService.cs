using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Interfaces
{
    public interface IHospitalService : IBaseCRUDService<HospitalDTO, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>
    {
        Task<PagedResult<DriveDTO>> Drives(string id, DriveSearchRequest request);
        Task<HtmlToPdfDocument> DrivesReport(string id, HospitalReportDrivesRequest request);
        Task<HtmlToPdfDocument> LitresByBloodTypeReport(string id, HospitalReportLitresRequest request);
    }
}
