using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;

namespace Vivel.Services
{
    public class FaqService : BaseCRUDService<FaqDTO, Faq, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>, IFaqService
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

            var faqs = await entity.GetPagedAsync(request.Page);

            var mappedList = _mapper.Map<List<FaqDTO>>(faqs.Results);

            return new PagedResult<FaqDTO>
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = faqs.PageCount,
                TotalItems = faqs.TotalItems
            };
        }
    }
}
