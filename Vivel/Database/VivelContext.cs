using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vivel.Model.Enums;

#nullable disable

namespace Vivel.Database
{
    public partial class VivelContext : DbContext
    {
        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Drive> Drives { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PresetBadge> PresetBadges { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BloodType> BloodTypes { get; set; }

        public VivelContext() { }
        public VivelContext(DbContextOptions<VivelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasConversion(
                        e => e.Name,
                        e => DonationStatus.FromName(e, false));
            });

            modelBuilder.Entity<Drive>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasConversion(
                        x => x.Name,
                        x => DriveStatus.FromName(x, false))
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleTimestampProperties();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            HandleTimestampProperties();

            return base.SaveChanges();
        }

        private void HandleTimestampProperties()
        {
            var AddedEntities = ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added).ToList();

            AddedEntities.ForEach(entry => entry.Property("CreatedAt").CurrentValue = DateTime.Now);

            var EditedEntities = ChangeTracker.Entries().Where(entry => entry.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(entry => entry.Property("UpdatedAt").CurrentValue = DateTime.Now);
        }
    }
}
