using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;

namespace Vivel.Services
{
    public class DonationService : BaseCRUDService<DonationDTO, Donation, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>, IDonationService
    {
        public DonationService(vivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<DonationDTO>> Get(DonationSearchRequest request = null)
        {
            var entity = _context.Set<Donation>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.UserId))
            {
                entity = entity.Where(x => x.UserId == request.UserId);
            }

            if (!string.IsNullOrWhiteSpace(request?.DriveId))
            {
                entity = entity.Where(x => x.DriveId == request.DriveId);
            }

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
