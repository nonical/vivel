using Microsoft.AspNetCore.Authorization;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;
using Vivel.Services;

namespace Vivel.Controllers
{
    [Authorize(Roles = "admin")]
    public class PresetBadgeController : BaseCRUDController<PresetBadgeDTO, PresetBadgeSearchRequest, PresetBadgeUpsertRequest, PresetBadgeUpsertRequest>
    {
        public PresetBadgeController(IPresetBadgeService service) : base(service)
        {
        }
    }
}
