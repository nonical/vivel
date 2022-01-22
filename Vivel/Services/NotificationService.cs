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
    }
}
