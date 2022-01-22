using System;
using System.Collections.Generic;
using System.Text;
using Vivel.Model.Dto;

namespace Vivel.Model.Requests.Drive
{
    public class DriveSearchRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string BloodType { get; set; }
        public int? Amount { get; set; }
        public string Status { get; set; }
        public bool? Urgency { get; set; }
    }
}
