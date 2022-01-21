using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;
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

            var list = await entity.ToListAsync();

            return _mapper.Map<List<DriveDTO>>(list);
        }

        public async Task<List<DonationDTO>> Donations(string id, DonationSearchRequest request)
        {
            var entity = _context.Donations.Where(x => x.DriveId == id).AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(request?.Status))
            {
                entity = entity.Where(x => x.Status == request.Status);
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<DonationDTO>>(list);
        }

    }
}
