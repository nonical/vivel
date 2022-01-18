using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Donation
{
    public class DonationSearchRequest
    {
        public string UserId { get; set; }
        public string DriveId { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public string Status { get; set; }
    }
}
