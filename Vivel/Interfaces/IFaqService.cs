using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;

namespace Vivel.Interfaces
{
    public interface IFaqService : IBaseCRUDService<FaqDTO, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
    }
}
