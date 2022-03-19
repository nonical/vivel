using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Drive : BaseModel
    {
        public Guid DriveId { get; set; }
        public Guid HospitalId { get; set; }
        public DateTime? Date { get; set; }
        public BloodType BloodType { get; set; }
        public int? Amount { get; set; }
        public bool Urgency { get; set; }

        public virtual DriveStatus Status { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
