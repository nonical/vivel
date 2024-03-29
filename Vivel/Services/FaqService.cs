﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Faq;

namespace Vivel.Services
{
    public class FaqService : BaseCRUDService<FaqDTO, Faq, FaqSearchRequest, FaqUpsertRequest, FaqUpsertRequest>, IFaqService
    {
        public FaqService(VivelContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<PagedResult<FaqDTO>> Get(FaqSearchRequest request = null)
        {
            var entity = _context.Set<Faq>().AsQueryable();

            if (request?.Answered != null)
            {
                entity = entity.Where(x => x.Answered == request.Answered);
            }

            return await entity.GetPagedAsync<Faq, FaqDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }
    }
}
