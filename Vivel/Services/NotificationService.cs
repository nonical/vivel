using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Notification;

namespace Vivel.Services
{
    public class NotificationService : BaseCRUDService<NotificationDTO, Notification, NotificationSearchRequest, NotificationInsertRequest, object>, INotificationService
    {
        public NotificationService(vivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<List<NotificationDTO>> Get(NotificationSearchRequest request = null)
        {
            var entity = _context.Set<Notification>().AsQueryable();

            if (request?.UserId != null)
            {
                entity = entity.Where(x => x.UserId == request.UserId);
            }

            // LinkId and LinkType are properties of a single linked item, thus searching them seperately does not make sense
            if (request?.LinkId != null && request.LinkType != null)
            {
                entity = entity.Where(x => x.LinkId == request.LinkId && x.LinkType == request.LinkType);
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<NotificationDTO>>(list);
        }
    }
}
