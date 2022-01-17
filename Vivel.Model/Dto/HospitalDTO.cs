using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class HospitalDTO
    {
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
