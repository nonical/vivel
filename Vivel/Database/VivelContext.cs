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

        public VivelContext() { }
        public VivelContext(DbContextOptions<VivelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.ToTable("Badge");

                entity.Property(e => e.BadgeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("BadgeID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PresetBadgeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.PresetBadge)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.PresetBadgeId)
                    .HasConstraintName("FK__Badge__PresetBad__30C33EC3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Badge__UserID__2FCF1A8A");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.ToTable("Donation");

                entity.Property(e => e.DonationId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DonationID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DriveId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DriveID")
                    .IsFixedLength(true);

                entity.Property(e => e.ScheduledAt).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasConversion(
                        e => e.Name,
                        e => DonationStatus.FromName(e, false))
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Drive)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.DriveId)
                    .HasConstraintName("FK__Donation__DriveI__37703C52");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Donation__UserID__367C1819");
            });

            modelBuilder.Entity<Drive>(entity =>
            {
                entity.ToTable("Drive");

                entity.Property(e => e.DriveId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DriveID")
                    .IsFixedLength(true);

                entity.Property(e => e.BloodType)
                    .HasConversion(
                        x => x.Name,
                        x => BloodType.FromName(x, false))
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HospitalId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("HospitalID")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasConversion(
                        x => x.Name,
                        x => DriveStatus.FromName(x, false))
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Drives)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Drive__HospitalI__339FAB6E");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Faqid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("FAQID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("Hospital");

                entity.Property(e => e.HospitalId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("HospitalID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Location).HasColumnType("geography");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("NotificationID")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.LinkId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("LinkID")
                    .IsFixedLength(true);

                entity.Property(e => e.LinkType).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__3A4CA8FD");
            });

            modelBuilder.Entity<PresetBadge>(entity =>
            {
                entity.ToTable("PresetBadge");

                entity.Property(e => e.PresetBadgeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.Property(e => e.BloodType)
                    .HasConversion(
                        x => x.Name,
                        x => BloodType.FromName(x, false))
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Location).HasColumnType("geography");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
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
