using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Notification
    {
        public string NotificationId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkId { get; set; }
        public string LinkType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
