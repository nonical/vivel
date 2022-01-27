using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.Notification;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class NotificationController : BaseCRUDController<NotificationDTO, NotificationSearchRequest, NotificationInsertRequest, object>
    {
        public NotificationController(INotificationService service) : base(service)
        {
        }

        [NonAction]
        public override Task<PagedResult<NotificationDTO>> Get(NotificationSearchRequest request)
        {
            return base.Get(request);
        }

        [NonAction]
        public override Task<NotificationDTO> Update(string id, [FromBody] object request)
        {
            return base.Update(id, request);
        }
    }
}
