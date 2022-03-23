using System;
using System.ComponentModel.DataAnnotations;

namespace Vivel.Identity.Data.Entities
{
    public class CoreUser
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool Verified { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
