using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Hospital
{
    public class HospitalUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public decimal? Latitude { get; set; }

        [Required]
        public decimal? Longitude { get; set; }
    }
}
