using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Hospital
    {
        public Hospital()
        {
            Drives = new HashSet<Drive>();
        }

        public string HospitalId { get; set; }
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Drive> Drives { get; set; }
    }
}
