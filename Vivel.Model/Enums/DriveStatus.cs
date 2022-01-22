using Ardalis.SmartEnum;

namespace Vivel.Model.Enums
{
    public sealed class DriveStatus : SmartEnum<DriveStatus>
    {
        public readonly static DriveStatus Open = new DriveStatus(nameof(Open), 1);
        public readonly static DriveStatus Closed = new DriveStatus(nameof(Closed), 2);

        public DriveStatus(string name, int value) : base(name, value) { }
    }
}
