using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vivel.Model.Pagination;

namespace Vivel.Extensions
{
    public static class LinqExtensions
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                TotalItems = await query.CountAsync()
            };

            if (page > 0)
            {
                var pageCount = (double)result.TotalItems / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * pageSize;
                result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();
            }
            else
            {
                result.PageCount = 1;
                result.Results = await query.ToListAsync();
            }

            return result;
        }
    }
}
