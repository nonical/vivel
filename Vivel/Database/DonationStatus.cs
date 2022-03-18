using System;

namespace Vivel.Database
{
    public class DonationStatus : BaseModel
    {
        public Guid DonationStatusId { get; set; }
        public string Name { get; set; }
    }
}
