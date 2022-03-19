using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Badge : BaseModel
    {
        public Guid BadgeId { get; set; }
        public Guid UserId { get; set; }
        public Guid PresetBadgeId { get; set; }
        public string Name { get; set; }

        public virtual PresetBadge PresetBadge { get; set; }
        public virtual User User { get; set; }
    }
}
