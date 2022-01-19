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
    }
}
