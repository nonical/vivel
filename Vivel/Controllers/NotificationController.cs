using Vivel.Model.Requests.Faq;
using Vivel.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vivel.Controllers
{
    public class NotificationController : BaseCRUDController<NotificationDTO, NotificationSearchRequest, NotificationInsertRequest, object>
    {
        public NotificationController(INotificationService service) : base(service)
        {
        }

        [NonAction]
        public override Task<NotificationDTO> Update(string id, [FromBody] object request)
        {
            return base.Update(id, request);
        }
    }
}
