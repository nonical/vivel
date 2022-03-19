using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivel.Database
{
    public partial class DriveStatus : BaseModel
    {
        public Guid DriveStatusId { get; set; }
        public string Name { get; set; }
    }
}
