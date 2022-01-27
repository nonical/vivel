using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Hospital
{
    public class HospitalSearchRequest : BaseSearchObject
    {
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
