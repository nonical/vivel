using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class PresetBadgeDTO
    {
        public string PresetBadgeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
