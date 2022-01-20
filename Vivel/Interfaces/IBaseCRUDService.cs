using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivel.Interfaces
{
    public interface IBaseCRUDService<Dto, SearchRequest, InsertRequest, UpdateRequest>
        where Dto : class
        where SearchRequest : class
        where InsertRequest : class
        where UpdateRequest : class
    {
        Task<List<Dto>> Get(SearchRequest request = null);

        Task<Dto> GetById(string id);

        Task<Dto> Insert(InsertRequest request);

        Task<Dto> Update(string id, UpdateRequest request);

        Task<Dto> Delete(string id);
    }
}
