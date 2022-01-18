using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Donation
{
    public class DonationUpdateRequest
    {
        public DateTime? ScheduledAt { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public int? LeukocyteCount { get; set; }
        public int? ErythrocyteCount { get; set; }
        public int? PlateletCount { get; set; }
    }
}
