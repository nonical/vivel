using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Notification : BaseModel
    {
        public string NotificationId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkId { get; set; }
        public string LinkType { get; set; }

        public virtual User User { get; set; }
    }
}
