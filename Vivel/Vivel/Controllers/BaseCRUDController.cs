using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vivel.Services;

namespace Vivel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseCRUDController<T, SearchRequest, InsertRequest, UpdateRequest> : ControllerBase
        where T : class
        where SearchRequest : class
        where InsertRequest : class
        where UpdateRequest : class
    {
        protected IBaseCRUDService<T, SearchRequest, InsertRequest, UpdateRequest> _service { get; set; }

        public BaseCRUDController(IBaseCRUDService<T, SearchRequest, InsertRequest, UpdateRequest> service)
        {
            _service = service;
        }

        [HttpGet]
        public async virtual Task<List<T>> Get([FromQuery] SearchRequest request)
        {
            return await _service.Get(request);
        }

        [HttpGet("{id}")]
        public async virtual Task<T> GetById(string id)
        {    
            return await _service.GetById(id);
        }

        [HttpPost]
        public async virtual Task<T> Insert([FromBody] InsertRequest request)
        {
            return await _service.Insert(request);
        }

        [HttpPut]
        public async virtual Task<T> Update(string id, [FromBody] UpdateRequest request)
        {
            return await _service.Update(id, request);
        }

        [HttpDelete]
        public async virtual Task<T> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
