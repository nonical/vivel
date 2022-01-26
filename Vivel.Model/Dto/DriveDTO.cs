using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class DriveDTO
    {
        public string DriveId { get; set; }
        public string HospitalId { get; set; }
        public DateTime? Date { get; set; }
        public string BloodType { get; set; }
        public int? Amount { get; set; }
        public string Status { get; set; }
        public bool? Urgency { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
