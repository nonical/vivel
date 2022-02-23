using System;
using System.Collections.Generic;
using System.Text;
using Vivel.Model.Dto;

namespace Vivel.Model.Requests.Drive
{
    public class DriveSearchRequest : BaseSearchObject
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public List<string> BloodType { get; set; }
        public int? Amount { get; set; }
        public List<string> Status { get; set; }
        public bool? Urgency { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
