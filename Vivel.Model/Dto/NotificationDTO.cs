using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class NotificationDTO
    {
        public string NotificationId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkId { get; set; }
        public string LinkType { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
