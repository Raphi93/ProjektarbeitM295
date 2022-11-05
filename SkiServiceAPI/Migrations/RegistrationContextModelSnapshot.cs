﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkiServiceAPI.Models;

#nullable disable

namespace SkiServiceAPI.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    partial class RegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkiServiceAPI.Models.Priorities", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"), 1L, 1);

                    b.Property<string>("Priority")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PriorityId");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Kommentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.Services", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.State", b =>
                {
                    b.Property<int?>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("StateId"), 1L, 1);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .HasMaxLength(2550)
                        .HasColumnType("nvarchar(2550)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.Registration", b =>
                {
                    b.HasOne("SkiServiceAPI.Models.Priorities", "Priority")
                        .WithMany("Registrations")
                        .HasForeignKey("PriorityId");

                    b.HasOne("SkiServiceAPI.Models.Services", "Service")
                        .WithMany("Registrations")
                        .HasForeignKey("ServiceId");

                    b.HasOne("SkiServiceAPI.Models.State", "State")
                        .WithMany("Registrations")
                        .HasForeignKey("StateId");

                    b.HasOne("SkiServiceAPI.Models.User", "User")
                        .WithMany("Registrations")
                        .HasForeignKey("UserId");

                    b.Navigation("Priority");

                    b.Navigation("Service");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.Priorities", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.Services", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.State", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SkiServiceAPI.Models.User", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
