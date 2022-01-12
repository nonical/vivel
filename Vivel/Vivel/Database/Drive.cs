using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Drive
    {
        public Drive()
        {
            Donations = new HashSet<Donation>();
        }

        public string DriveId { get; set; }
        public string HospitalId { get; set; }
        public DateTime? Date { get; set; }
        public string BloodType { get; set; }
        public int? Amount { get; set; }
        public string Status { get; set; }
        public bool? Urgency { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
