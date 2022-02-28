using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Hospital.Reports
{
    public class HospitalReportDrivesRequest
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public string Status { get; set; }
        public bool? Urgency { get; set; }
    }
}
