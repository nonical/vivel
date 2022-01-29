using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Services
{
    public class PresetBadgeService : BaseCRUDService<PresetBadgeDTO, PresetBadge, PresetBadgeSearchRequest, PresetBadgeUpsertRequest, PresetBadgeUpsertRequest>, IPresetBadgeService
    {
        public PresetBadgeService(VivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<PagedResult<PresetBadgeDTO>> Get(PresetBadgeSearchRequest request = null)
        {
            var entity = _context.Set<PresetBadge>().AsQueryable();

            if (request?.Name != null)
            {
                entity = entity.Where(x => x.Name.Contains(request.Name));
            }

            var presetBadges = await entity.GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<PresetBadgeDTO>>(presetBadges.Results);

            return new PagedResult<PresetBadgeDTO>
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = presetBadges.PageCount,
                TotalItems = presetBadges.TotalItems
            };
        }
    }
}
