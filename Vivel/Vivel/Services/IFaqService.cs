using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Requests.Faq;

namespace Vivel.Services
{
    public interface IFaqService : IBaseCRUDService<Dto.Faq, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
    }
}
