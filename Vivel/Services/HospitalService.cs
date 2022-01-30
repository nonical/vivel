using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Hospital;

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
    }
}
