using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Drive;

namespace Vivel.Services
{
    public class DriveService : BaseCRUDService<DriveDTO, Drive, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>, IDriveService
    {
        public DriveService(vivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<DriveDTO>> Get(DriveSearchRequest request = null)
        {
            var entity = _context.Set<Drive>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.HospitalId))
            {
                entity = entity.Where(x => x.HospitalId == request.HospitalId);
            }

            if (request?.FromDate != null)
            {
                entity = entity.Where(x => x.Date >= request.FromDate);

            }

            if (request?.ToDate != null)
            {
                entity = entity.Where(x => x.Date <= request.ToDate);
            }

            if (!string.IsNullOrWhiteSpace(request?.BloodType))
            {
                entity = entity.Where(x => x.BloodType == request.BloodType);
            }

            if (request?.Amount != null)
            {
                entity = entity.Where(x => x.Amount == request.Amount);
            }

            if (!string.IsNullOrWhiteSpace(request?.Status))
            {
                entity = entity.Where(x => x.Status == request.Status);
            }

            if (request?.IncludeHospital == true)
            {
                entity = entity.Include(x => x.Hospital);
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<DriveDTO>>(list);
        }
    }
}
