﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spinalproject.src.appointDbContext;

#nullable disable

namespace spinalproject.Migrations
{
    [DbContext(typeof(appointDbContext))]
    partial class appointDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("AppointmentEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserEntityid")
                        .HasColumnType("TEXT");

                    b.Property<string>("appointmentDetails")
                        .HasColumnType("TEXT")
                        .HasColumnName("appointmentDetails");

                    b.Property<DateTime>("appointment_time")
                        .HasColumnType("TEXT")
                        .HasColumnName("appointment_time");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("patient_id")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("patient_id");

                    b.Property<Guid?>("reportDetails")
                        .HasColumnType("TEXT")
                        .HasColumnName("report_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("status");

                    b.HasKey("id");

                    b.HasIndex("UserEntityid");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("ReportEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserEntityid")
                        .HasColumnType("TEXT");

                    b.Property<int>("cab_angle")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cab_angle");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("diagnosis")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("diagnosis");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("notes");

                    b.Property<Guid>("patient_id")
                        .HasColumnType("TEXT")
                        .HasColumnName("patient_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("status");

                    b.HasKey("id");

                    b.HasIndex("UserEntityid");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("UserEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Role");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("email_address");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AppointmentEntity", b =>
                {
                    b.HasOne("UserEntity", null)
                        .WithMany("Appointments")
                        .HasForeignKey("UserEntityid");
                });

            modelBuilder.Entity("ReportEntity", b =>
                {
                    b.HasOne("UserEntity", null)
                        .WithMany("Reports")
                        .HasForeignKey("UserEntityid");
                });

            modelBuilder.Entity("UserEntity", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
