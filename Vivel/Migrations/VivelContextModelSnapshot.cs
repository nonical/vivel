﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Vivel.Database;

namespace Vivel.Migrations
{
    [DbContext(typeof(VivelContext))]
    partial class VivelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vivel.Database.Badge", b =>
                {
                    b.Property<string>("BadgeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresetBadgeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BadgeId");

                    b.HasIndex("PresetBadgeId");

                    b.HasIndex("UserId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("Vivel.Database.BloodType", b =>
                {
                    b.Property<Guid>("BloodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("BloodTypeId");

                    b.ToTable("BloodTypes");
                });

            modelBuilder.Entity("Vivel.Database.Donation", b =>
                {
                    b.Property<string>("DonationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ScheduledAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StatusDonationStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DonationId");

                    b.HasIndex("DriveId");

                    b.HasIndex("StatusDonationStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Vivel.Database.DonationReport", b =>
                {
                    b.Property<Guid>("DonationReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ErythrocyteCount")
                        .HasColumnType("int");

                    b.Property<int?>("LeukocyteCount")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlateletCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DonationReportId");

                    b.HasIndex("DonationId")
                        .IsUnique()
                        .HasFilter("[DonationId] IS NOT NULL");

                    b.ToTable("DonationReports");
                });

            modelBuilder.Entity("Vivel.Database.DonationStatus", b =>
                {
                    b.Property<Guid>("DonationStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DonationStatusId");

                    b.ToTable("DonationStatuses");
                });

            modelBuilder.Entity("Vivel.Database.Drive", b =>
                {
                    b.Property<string>("DriveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("BloodTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("StatusDriveStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Urgency")
                        .HasColumnType("bit");

                    b.HasKey("DriveId");

                    b.HasIndex("BloodTypeId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("StatusDriveStatusId");

                    b.ToTable("Drives");
                });

            modelBuilder.Entity("Vivel.Database.DriveStatus", b =>
                {
                    b.Property<Guid>("DriveStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DriveStatusId");

                    b.ToTable("DriveStatuses");
                });

            modelBuilder.Entity("Vivel.Database.Faq", b =>
                {
                    b.Property<string>("Faqid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answered")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Faqid");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("Vivel.Database.Hospital", b =>
                {
                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Vivel.Database.Notification", b =>
                {
                    b.Property<string>("NotificationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Vivel.Database.PresetBadge", b =>
                {
                    b.Property<string>("PresetBadgeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PresetBadgeId");

                    b.ToTable("PresetBadges");
                });

            modelBuilder.Entity("Vivel.Database.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("BloodTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Verified")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vivel.Database.Badge", b =>
                {
                    b.HasOne("Vivel.Database.PresetBadge", "PresetBadge")
                        .WithMany("Badges")
                        .HasForeignKey("PresetBadgeId");

                    b.HasOne("Vivel.Database.User", "User")
                        .WithMany("Badges")
                        .HasForeignKey("UserId");

                    b.Navigation("PresetBadge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vivel.Database.Donation", b =>
                {
                    b.HasOne("Vivel.Database.Drive", "Drive")
                        .WithMany("Donations")
                        .HasForeignKey("DriveId");

                    b.HasOne("Vivel.Database.DonationStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusDonationStatusId");

                    b.HasOne("Vivel.Database.User", "User")
                        .WithMany("Donations")
                        .HasForeignKey("UserId");

                    b.Navigation("Drive");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vivel.Database.DonationReport", b =>
                {
                    b.HasOne("Vivel.Database.Donation", "Donation")
                        .WithOne("DonationReport")
                        .HasForeignKey("Vivel.Database.DonationReport", "DonationId");

                    b.Navigation("Donation");
                });

            modelBuilder.Entity("Vivel.Database.Drive", b =>
                {
                    b.HasOne("Vivel.Database.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId");

                    b.HasOne("Vivel.Database.Hospital", "Hospital")
                        .WithMany("Drives")
                        .HasForeignKey("HospitalId");

                    b.HasOne("Vivel.Database.DriveStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusDriveStatusId");

                    b.Navigation("BloodType");

                    b.Navigation("Hospital");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Vivel.Database.Notification", b =>
                {
                    b.HasOne("Vivel.Database.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vivel.Database.User", b =>
                {
                    b.HasOne("Vivel.Database.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId");

                    b.Navigation("BloodType");
                });

            modelBuilder.Entity("Vivel.Database.Donation", b =>
                {
                    b.Navigation("DonationReport");
                });

            modelBuilder.Entity("Vivel.Database.Drive", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("Vivel.Database.Hospital", b =>
                {
                    b.Navigation("Drives");
                });

            modelBuilder.Entity("Vivel.Database.PresetBadge", b =>
                {
                    b.Navigation("Badges");
                });

            modelBuilder.Entity("Vivel.Database.User", b =>
                {
                    b.Navigation("Badges");

                    b.Navigation("Donations");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
