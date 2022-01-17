using Vivel.Model.Requests.Faq;
using Vivel.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Controllers
{
    public class PresetBadgeController : BaseCRUDController<PresetBadgeDTO, PresetBadgeSearchRequest, PresetBadgeInsertRequest, PresetBadgeUpdateRequest>
    {
        public PresetBadgeController(IPresetBadgeService service) : base(service)
        {
        }
    }
}
