using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Model.Pagination;

namespace Vivel.Extensions
{
    public static class LinqExtensions
    {
        public static async Task<PagedResult<Dto>> GetPagedAsync<T, Dto>(this IQueryable<T> query, IMapper _mapper, int page, int pageSize) where T : class where Dto : class
        {
            var result = new PagedResult<Dto>
            {
                CurrentPage = page,
                TotalItems = await query.CountAsync()
            };

            if (page > 0)
            {
                var pageCount = (double)result.TotalItems / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * pageSize;

                var list = await query.Skip(skip).Take(pageSize).ToListAsync();

                result.Results = _mapper.Map<List<Dto>>(list);
            }
            else
            {
                result.PageCount = 1;

                var list = await query.ToListAsync();

                result.Results = _mapper.Map<List<Dto>>(list);
            }

            return result;
        }
    }
}
