using Microsoft.EntityFrameworkCore;
using Vivel.Identity.Data.Entities;

namespace Vivel.Identity.Data
{
    public class CoreDbContext : DbContext
    {
        public virtual DbSet<CoreUser> Users { get; set; }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }
    }
}
