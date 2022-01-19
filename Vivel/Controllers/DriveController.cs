using Vivel.Model.Dto;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class DriveController : BaseCRUDController<DriveDTO, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>
    {
        public DriveController(IDriveService service) : base(service)
        {
        }
    }
}
