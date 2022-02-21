using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;

namespace Vivel.Services
{
    public class NotificationService : BaseCRUDService<NotificationDTO, Notification, NotificationSearchRequest, NotificationInsertRequest, object>, INotificationService
    {
        public NotificationService(VivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task PostNotifications<T>(List<string> userIds, string linkId, string title, string content)
        {
            var notifications = userIds.Select(userId => new Notification
            {
                UserId = userId,
                LinkId = linkId,
                LinkType = typeof(T).Name,
                Title = title,
                Content = content,

            });

            await _context.AddRangeAsync(notifications);
            await _context.SaveChangesAsync();
        }
    }
}
