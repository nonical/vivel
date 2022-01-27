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
using Vivel.Model.Enums;
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
            var entity = _context.Set<Donation>().AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Select(x => DonationStatus.FromName(x, false)).Any(y => y == donation.Status));
            }

            var donations = await entity.GetPagedAsync(request.Page);

            var mappedList = _mapper.Map<List<DonationDTO>>(donations.Results);

            return new PagedResult<DonationDTO>()
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = donations.PageCount,
                TotalItems = donations.TotalItems
            };
        }
    }
}
