using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class FaqController : BaseCRUDController<Dto.Faq, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
        public FaqController(IFaqService service) : base(service)
        {
        }
    }
}
