using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Services
{
    public class DriveService : BaseCRUDService<DriveDTO, Drive, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>, IDriveService
    {
        public DriveService(VivelContext context, IMapper mapper) : base(context, mapper)
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
                entity = entity.Where(drive => request.Status.Any(x => x.Equals(drive.Status)));
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

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Any(x => x.Equals(donation.Status)));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<DonationDTO>>(list);
        }

    }
}
