using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivel.Database
{
    public partial class DonationReport : BaseModel
    {
        public Guid DonationReportId { get; set; }
        public Guid DonationId { get; set; }
        public string Note { get; set; }
        public int? LeukocyteCount { get; set; }
        public int? ErythrocyteCount { get; set; }
        public int? PlateletCount { get; set; }

        public virtual Donation Donation { get; set; }
    }
}
