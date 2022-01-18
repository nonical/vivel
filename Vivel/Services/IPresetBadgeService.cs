using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Services
{
    public interface IPresetBadgeService : IBaseCRUDService<PresetBadgeDTO, PresetBadgeSearchRequest, PresetBadgeUpsertRequest, PresetBadgeUpsertRequest>
    {
    }
}
