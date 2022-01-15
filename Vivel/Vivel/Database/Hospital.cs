using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Hospital : BaseModel
    {
        public Hospital()
        {
            Drives = new HashSet<Drive>();
        }

        public string HospitalId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual ICollection<Drive> Drives { get; set; }
    }
}
