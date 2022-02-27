using System;
using System.ComponentModel;
using Vivel.Model.Enums;

#nullable disable

namespace Vivel.Database
{
    public partial class Donation : BaseModel
    {
        public string DonationId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string DriveId { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public int? Amount { get; set; }
        public DonationStatus Status { get; set; } = DonationStatus.Pending;

        public string Note { get; set; }
        public int? LeukocyteCount { get; set; }
        public int? ErythrocyteCount { get; set; }
        public int? PlateletCount { get; set; }

        public virtual Drive Drive { get; set; }
        public virtual User User { get; set; }
    }
}
