using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class PresetBadgeController : BaseCRUDController<PresetBadgeDTO, PresetBadgeSearchRequest, PresetBadgeUpsertRequest, PresetBadgeUpsertRequest>
    {
        public PresetBadgeController(IPresetBadgeService service) : base(service)
        {
        }
    }
}
