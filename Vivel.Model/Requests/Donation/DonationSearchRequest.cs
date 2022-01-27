﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Donation
{
    public class DonationSearchRequest : BaseSearchObject
    {
        public DateTime? ScheduledAt { get; set; }
        public List<string> Status { get; set; }
    }
}
