using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;

namespace Vivel.Services
{
    public class FaqService : BaseCRUDService<FaqDTO, Faq, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>, IFaqService
    {
        public FaqService(vivelContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<FaqDTO>> Get(FaqSearchRequest request = null)
        {
            var entity = _context.Set<Faq>().AsQueryable();

            if (request?.Answered != null)
            {
                entity = entity.Where(x => x.Answered == request.Answered);
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<FaqDTO>>(list);
        }
    }
}
