using System;
using System.Threading.Tasks;
using Vivel.Model.Pagination;

namespace Vivel.Interfaces
{
    public interface IBaseCRUDService<Dto, SearchRequest, InsertRequest, UpdateRequest>
        where Dto : class
        where SearchRequest : class
        where InsertRequest : class
        where UpdateRequest : class
    {
        Task<PagedResult<Dto>> Get(SearchRequest request = null);

        Task<Dto> GetById(Guid id);

        Task<Dto> Insert(InsertRequest request);

        Task<Dto> Update(Guid id, UpdateRequest request);

        Task<Dto> Delete(Guid id);
    }
}
