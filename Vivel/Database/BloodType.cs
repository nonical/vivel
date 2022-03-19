using System;

namespace Vivel.Database
{
    public class BloodType : BaseModel
    {
        public Guid BloodTypeId { get; set; }
        public string Name { get; set; }
    }
}
