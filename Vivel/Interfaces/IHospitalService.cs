using System;
using System.Threading.Tasks;
using DinkToPdf;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Interfaces
{
    public interface IHospitalService : IBaseCRUDService<HospitalDTO, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>
    {
        Task<PagedResult<DriveDTO>> Drives(Guid id, DriveSearchRequest request);
        Task<HtmlToPdfDocument> DrivesReport(Guid id, HospitalReportDrivesRequest request);
        Task<HtmlToPdfDocument> LitresByBloodTypeReport(Guid id, HospitalReportLitresRequest request);
    }
}
