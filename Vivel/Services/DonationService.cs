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

namespace Vivel.Services
{
    public class DonationService : BaseCRUDService<DonationDTO, Donation, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>, IDonationService
    {
        public DonationService(VivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<DonationDTO>> Get(DonationSearchRequest request = null)
        {
            var entity = _context.Set<Donation>().AsQueryable();

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
