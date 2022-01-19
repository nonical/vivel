using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Hospital;

namespace Vivel.Services
{
    public class HospitalService : BaseCRUDService<HospitalDTO, Hospital, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>, IHospitalService
    {
        public HospitalService(vivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<HospitalDTO>> Get(HospitalSearchRequest request = null)
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

            var list = await entity.ToListAsync();

            return _mapper.Map<List<HospitalDTO>>(list);
        }
    }
}
