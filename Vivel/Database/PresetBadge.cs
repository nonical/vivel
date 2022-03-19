using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class PresetBadge : BaseModel
    {
        public Guid PresetBadgeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
    }
}
