using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;

namespace Vivel.Interfaces
{
    public interface INotificationService : IBaseCRUDService<NotificationDTO, NotificationSearchRequest, NotificationInsertRequest, object>
    {
        Task PostNotifications<T>(List<Guid> userIds, Guid linkId, string title, string content);
    }
}
