using Ardalis.SmartEnum;

namespace Vivel.Model.Enums
{
    public sealed class DonationStatus : SmartEnum<DonationStatus>
    {
        public readonly static DonationStatus Pending = new DonationStatus(nameof(Pending), 1);
        public readonly static DonationStatus Scheduled = new DonationStatus(nameof(Scheduled), 2);
        public readonly static DonationStatus Rejected = new DonationStatus(nameof(Rejected), 3);
        public readonly static DonationStatus Approved = new DonationStatus(nameof(Approved), 4);

        public DonationStatus(string name, int value) : base(name, value) { }
    }
}
