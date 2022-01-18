using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Drive
{
    public class DriveInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string HospitalId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public DateTime? Date { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string BloodType { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int? Amount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Status { get; set; }

        [Required(AllowEmptyStrings = false)]
        public bool? Urgency { get; set; }
    }
}
