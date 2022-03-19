using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Notification;

namespace Vivel.Controllers
{
    [Authorize(Roles = "admin")]
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
        public override Task<ActionResult<NotificationDTO>> Update(Guid id, [FromBody] object request)
        {
            return base.Update(id, request);
        }
    }
}
