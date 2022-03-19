using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Notification : BaseModel
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid LinkId { get; set; }
        public string LinkType { get; set; }

        public virtual User User { get; set; }
    }
}
