using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;

namespace Vivel.Interfaces
{
    public interface IFaqService : IBaseCRUDService<FaqDTO, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
    }
}
