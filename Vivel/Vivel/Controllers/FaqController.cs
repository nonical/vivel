using Vivel.Model.Requests.Faq;
using Vivel.Services;
using Vivel.Model.Dto;

namespace Vivel.Controllers
{
    public class FaqController : BaseCRUDController<FaqDTO, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
        public FaqController(IFaqService service) : base(service)
        {
        }
    }
}
