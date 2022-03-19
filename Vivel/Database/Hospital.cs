using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace Vivel.Database
{
    public partial class Hospital : BaseModel
    {
        public Hospital()
        {
            Drives = new HashSet<Drive>();
        }

        public Guid HospitalId { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        public virtual ICollection<Drive> Drives { get; set; }
    }
}
