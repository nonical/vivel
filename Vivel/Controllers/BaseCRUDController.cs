using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Pagination;
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
        public async virtual Task<PagedResult<T>> Get([FromQuery] SearchRequest request)
        {
            return await _service.Get(request);
        }

        [HttpGet("{id}")]
        public async virtual Task<ActionResult<T>> GetById(string id)
        {
            var entity = await _service.GetById(id);
            if (entity != null)
            {
                return new OkObjectResult(entity);
            }
            else
            {
                return new NotFoundResult();
            }

        }

        [HttpPost]
        public async virtual Task<ActionResult<T>> Insert([FromBody] InsertRequest request)
        {
            var entity = await _service.Insert(request);

            if (entity != null)
            {
                return new ObjectResult(entity) { StatusCode = StatusCodes.Status201Created };
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{id}")]
        public async virtual Task<ActionResult<T>> Update(string id, [FromBody] UpdateRequest request)
        {
            var entity = await _service.Update(id, request);

            if (entity != null)
            {
                return new OkObjectResult(entity);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpDelete]
        public async virtual Task<ActionResult<T>> Delete(string id)
        {
            var entity = await _service.Delete(id);

            if (entity != null)
            {
                return new OkObjectResult(entity);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
