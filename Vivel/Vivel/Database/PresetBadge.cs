using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class PresetBadge
    {
        public PresetBadge()
        {
            Badges = new HashSet<Badge>();
        }

        public string PresetBadgeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
    }
}
