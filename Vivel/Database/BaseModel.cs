using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivel.Database
{
    public class BaseModel
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
