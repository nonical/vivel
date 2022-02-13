﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;

namespace Vivel.Services
{
    public class DonationService : BaseCRUDService<DonationDTO, Donation, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>, IDonationService
    {
        public DonationService(VivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<PagedResult<DonationDTO>> Get(DonationSearchRequest request = null)
        {
            var entity = _context.Set<Donation>().Include(x => x.User).AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Select(x => DonationStatus.FromName(x, false)).Any(y => y == donation.Status));
            }

            return await entity.GetPagedAsync<Donation, DonationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }
    }
}
