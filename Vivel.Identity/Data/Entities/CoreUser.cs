using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vivel.Identity.Data.Entities
{
    public class CoreUser
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool Verified { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
