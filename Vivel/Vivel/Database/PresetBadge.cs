using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class PresetBadge : BaseModel
    {
        public PresetBadge()
        {
            Badges = new HashSet<Badge>();
        }

        public string PresetBadgeId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
    }
}
