using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Badge : BaseModel
    {
        public string BadgeId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string PresetBadgeId { get; set; }
        public string Name { get; set; }

        public virtual PresetBadge PresetBadge { get; set; }
        public virtual User User { get; set; }
    }
}
