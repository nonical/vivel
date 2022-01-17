﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Services
{
    public class PresetBadgeService : BaseCRUDService<PresetBadgeDTO, PresetBadge, PresetBadgeSearchRequest, PresetBadgeInsertRequest, PresetBadgeUpdateRequest>, IPresetBadgeService
    {
        public PresetBadgeService(vivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<PresetBadgeDTO>> Get(PresetBadgeSearchRequest request = null)
        {
            var entity = _context.Set<PresetBadge>().AsQueryable();

            if (request?.Name != null)
            {
                entity = entity.Where(x => x.Name.Contains(request.Name));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<PresetBadgeDTO>>(list);
        }
    }
}