using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelectPdf;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Helpers.Reports;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Services
{
    public class HospitalService : BaseCRUDService<HospitalDTO, Hospital, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>, IHospitalService
    {
        public HospitalService(VivelContext context, IMapper mapper) : base(context, mapper) { }

        public async override Task<PagedResult<HospitalDTO>> Get(HospitalSearchRequest request = null)
        {
            var entity = _context.Set<Hospital>().AsQueryable();

            if (request?.Name != null)
            {
                entity = entity.Where(x => x.Name.Contains(request.Name));
            }

            if (request?.Latitude != null)
            {
                entity = entity.Where(x => x.Latitude == request.Latitude);
            }

            if (request?.Longitude != null)
            {
                entity = entity.Where(x => x.Longitude == request.Longitude);
            }

            return await entity.GetPagedAsync<Hospital, HospitalDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<PagedResult<DriveDTO>> Drives(string id, DriveSearchRequest request)
        {
            var entity = _context.Drives.Where(x => x.HospitalId == id).AsQueryable();

            if (request?.FromDate != null)
            {
                entity = entity.Where(x => x.Date >= request.FromDate);

            }

            if (request?.ToDate != null)
            {
                entity = entity.Where(x => x.Date <= request.ToDate);
            }

            if (request?.BloodType?.Count > 0)
            {
                entity = entity.Where(drive => request.BloodType.Select(x => BloodType.FromName(x, false)).Any(z => z == drive.BloodType));
            }

            if (request?.Amount != null)
            {
                entity = entity.Where(x => x.Amount == request.Amount);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(drive => request.Status.Select(x => DriveStatus.FromName(x, false)).Any(y => y == drive.Status));
            }

            return await entity.GetPagedAsync<Drive, DriveDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<byte[]> DrivesReport(string id, HospitalReportDrivesRequest request)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            var drives = _context.Drives.Include(x => x.Donations).AsQueryable();

            if (request.Urgency != null)
            {
                drives = drives.Where(x => x.Urgency == request.Urgency);
            }

            if (request.Status != null)
            {
                var status = DriveStatus.FromName(request.Status, true);

                drives = drives.Where(x => x.Status == status);
            }

            drives = drives.Where(x => x.HospitalId == id && request.From <= x.Date && x.Date <= request.To)
                            .OrderBy(x => x.Date);

            var entities = await drives.ToListAsync();

            var html = new DrivesReportHelper
            {
                HospitalName = hospital.Name,
                drives = entities,
                Description = $"Drives report for period {request.From:MMM dd yyyy} - {request.To:MMM dd yyyy}"
            }.GetHtml();

            return HtmlToByteArrayHelper.GetBytes(html);
        }

        public async Task<byte[]> LitresByBloodTypeReport(string id, HospitalReportLitresRequest request)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            var drives = _context.Drives.AsQueryable();

            if (request.Urgency != null)
            {
                drives = drives.Where(x => x.Urgency == request.Urgency);
            }

            drives = drives.Where(x => x.HospitalId == id && x.Status == DriveStatus.Closed);

            var stats = await drives.GroupBy(x => x.BloodType)
                                    .Select(x => new LitresByBloodTypeDTO
                                    {
                                        BloodType = x.Key.Name,
                                        Amount = x.Sum(z => (int)z.Amount) / 1000.00
                                    })
                                    .ToListAsync();

            var html = new LitresByBloodTypeHelper
            {
                HospitalName = hospital.Name,
                Stats = stats,
                Description = $"Litres by blood type report for period {request.From:MMM dd yyyy} - {request.To:MMM dd yyyy}"
            }.GetHtml();

            return HtmlToByteArrayHelper.GetBytes(html);
        }
    }
}
