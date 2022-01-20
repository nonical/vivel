using Ardalis.SmartEnum;

namespace Vivel.Model.Enums
{
    public sealed class BloodType : SmartEnum<BloodType>
    {
        public readonly static BloodType APositive = new BloodType("A+", 1);
        public readonly static BloodType ANegative = new BloodType("A-", 2);
        public readonly static BloodType BPositive = new BloodType("B+", 3);
        public readonly static BloodType BNegative = new BloodType("B-", 4);
        public readonly static BloodType ABPositive = new BloodType("AB+", 5);
        public readonly static BloodType ABNegative = new BloodType("AB-", 6);
        public readonly static BloodType OPositive = new BloodType("O+", 7);
        public readonly static BloodType ONegative = new BloodType("O-", 8);


        private BloodType(string name, int value) : base(name, value)
        {
        }
    }
}
