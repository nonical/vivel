using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Drive
{
    public class DriveUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public DateTime? Date { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string BloodType { get; set; }

        [Required]
        public int? Amount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Status { get; set; }

        [Required]
        public bool? Urgency { get; set; }
    }
}
