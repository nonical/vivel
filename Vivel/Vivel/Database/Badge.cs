using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Badge
    {
        public string BadgeId { get; set; }
        public string UserId { get; set; }
        public string PresetBadgeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual PresetBadge PresetBadge { get; set; }
        public virtual User User { get; set; }
    }
}
