using System;

#nullable disable

namespace Vivel.Database
{
    public partial class Donation : BaseModel
    {
        public Guid DonationId { get; set; }
        public Guid UserId { get; set; }
        public Guid DriveId { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public int? Amount { get; set; }
        public DonationStatus Status { get; set; }

        public virtual Drive Drive { get; set; }
        public virtual User User { get; set; }
        public virtual DonationReport DonationReport { get; set; }
    }
}
