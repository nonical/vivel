using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class DonationDTO
    {
        public string DonationId { get; set; }
        public string UserId { get; set; }
        public string DriveId { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public int? LeukocyteCount { get; set; }
        public int? ErythrocyteCount { get; set; }
        public int? PlateletCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
