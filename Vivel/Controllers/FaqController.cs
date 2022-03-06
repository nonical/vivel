using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class FaqController : BaseCRUDController<FaqDTO, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
        public FaqController(IFaqService service) : base(service)
        {
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<FaqDTO>> Update(string id, [FromBody] FaqUpdateRequest request)
        {
            return await base.Update(id, request);
        }
    }
}
