using System;
using System.Collections.Generic;
using Vivel.Model.Enums;

#nullable disable

namespace Vivel.Database
{
    public partial class Drive : BaseModel
    {
        public string DriveId { get; set; } = Guid.NewGuid().ToString();
        public string HospitalId { get; set; }
        public DateTime? Date { get; set; }
        public BloodType BloodType { get; set; }
        public int? Amount { get; set; }
        public DriveStatus Status { get; set; } = DriveStatus.Open;
        public bool Urgency { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
