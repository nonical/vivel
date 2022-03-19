﻿using System;
using System.Collections.Generic;

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
        public bool Urgency { get; set; }

        public virtual DriveStatus Status { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
