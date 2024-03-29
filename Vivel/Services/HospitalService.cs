﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Helpers.Reports;
using Vivel.Interfaces;
using Vivel.Model.Dto;
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

            return await entity.GetPagedAsync<Hospital, HospitalDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<PagedResult<DriveDTO>> Drives(Guid id, DriveSearchRequest request)
        {
            var entity = _context.Drives
                .Include(x => x.Status)
                .Include(x => x.BloodType)
                .Where(x => x.HospitalId == id)
                .AsQueryable();

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
                entity = entity.Where(drive => request.BloodType.Any(x => x == drive.BloodType.Name));
            }

            if (request?.Amount != null)
            {
                entity = entity.Where(x => x.Amount == request.Amount);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(drive => request.Status.Contains(drive.Status.Name));
            }

            return await entity.GetPagedAsync<Drive, DriveDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<HtmlToPdfDocument> DrivesReport(Guid id, HospitalReportDrivesRequest request)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            var drives = _context.Drives
                .Include(x => x.Status)
                .Include(x => x.BloodType)
                .Include(x => x.Donations)
                .AsQueryable();

            if (request.Urgency != null)
            {
                drives = drives.Where(x => x.Urgency == request.Urgency);
            }

            if (request.Status != null)
            {
                drives = drives.Where(x => x.Status.Name == request.Status);
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

            return HtmlToPdfHelper.GetPdfDocument(html);
        }

        public async Task<HtmlToPdfDocument> LitresByBloodTypeReport(Guid id, HospitalReportLitresRequest request)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            var drives = _context.Drives
                .Include(x => x.Status)
                .Include(x => x.BloodType)
                .AsQueryable();

            if (request.Urgency != null)
            {
                drives = drives.Where(x => x.Urgency == request.Urgency);
            }

            drives = drives.Where(x => x.HospitalId == id && x.Status.Name == "Closed");

            var stats = await drives.GroupBy(x => x.BloodType.Name)
                                    .Select(x => new LitresByBloodTypeDTO
                                    {
                                        BloodType = x.Key,
                                        Amount = x.Sum(z => (int)z.Amount) / 1000.00
                                    })
                                    .ToListAsync();

            var html = new LitresByBloodTypeHelper
            {
                HospitalName = hospital.Name,
                Stats = stats,
                Description = $"Litres by blood type report for period {request.From:MMM dd yyyy} - {request.To:MMM dd yyyy}"
            }.GetHtml();

            return HtmlToPdfHelper.GetPdfDocument(html);
        }
    }
}
