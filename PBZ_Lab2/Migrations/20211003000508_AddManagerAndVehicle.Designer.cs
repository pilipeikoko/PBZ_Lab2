﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBZ_Lab2.Web.Data;

namespace PBZ_Lab2.Web.Migrations
{
    [DbContext(typeof(PBZ_Lab2WebContext))]
    [Migration("20211003000508_AddManagerAndVehicle")]
    partial class AddManagerAndVehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<Guid?>("RentRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RentRecordId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkingYearExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.RentRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("RentRecord");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DrivingLicensePhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrivingYearExperience")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassportPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<bool>("isBlocker")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ManagerId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Location", b =>
                {
                    b.HasOne("PBZ_Lab2.Web.Domain.Models.RentRecord", null)
                        .WithMany("Locations")
                        .HasForeignKey("RentRecordId");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.RentRecord", b =>
                {
                    b.HasOne("PBZ_Lab2.Web.Domain.Models.User", null)
                        .WithMany("RentRecords")
                        .HasForeignKey("UserId");

                    b.HasOne("PBZ_Lab2.Web.Domain.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.User", b =>
                {
                    b.HasOne("PBZ_Lab2.Web.Domain.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("PBZ_Lab2.Web.Domain.Models.Manager", null)
                        .WithMany("Users")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Vehicle", b =>
                {
                    b.HasOne("PBZ_Lab2.Web.Domain.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.Manager", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.RentRecord", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("PBZ_Lab2.Web.Domain.Models.User", b =>
                {
                    b.Navigation("RentRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
