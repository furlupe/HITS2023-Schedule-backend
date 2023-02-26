﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Schedule.Utils;

#nullable disable

namespace Schedule.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Schedule.Models.BlacklistedToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Blacklist");
                });

            modelBuilder.Entity("Schedule.Models.Cabinet", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Number");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("Schedule.Models.Group", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uuid");

                    b.HasKey("Number");

                    b.HasIndex("LessonId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Number = 972103
                        },
                        new
                        {
                            Number = 972201
                        });
                });

            modelBuilder.Entity("Schedule.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CabinetNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TimeslotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CabinetNumber");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimeslotId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Schedule.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Schedule.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Schedule.Models.Timeslot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("Schedule.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("GroupNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TeacherProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupNumber");

                    b.HasIndex("TeacherProfileId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1fca986-3b9b-467c-8a93-f3e972300573"),
                            Login = "furlupe",
                            Password = "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB",
                            Role = 4
                        });
                });

            modelBuilder.Entity("Schedule.Models.Group", b =>
                {
                    b.HasOne("Schedule.Models.Lesson", null)
                        .WithMany("Groups")
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("Schedule.Models.Lesson", b =>
                {
                    b.HasOne("Schedule.Models.Cabinet", "Cabinet")
                        .WithMany()
                        .HasForeignKey("CabinetNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Timeslot", "Timeslot")
                        .WithMany()
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");

                    b.Navigation("Timeslot");
                });

            modelBuilder.Entity("Schedule.Models.Subject", b =>
                {
                    b.HasOne("Schedule.Models.Teacher", null)
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Schedule.Models.User", b =>
                {
                    b.HasOne("Schedule.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupNumber");

                    b.HasOne("Schedule.Models.Teacher", "TeacherProfile")
                        .WithMany()
                        .HasForeignKey("TeacherProfileId");

                    b.Navigation("Group");

                    b.Navigation("TeacherProfile");
                });

            modelBuilder.Entity("Schedule.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Schedule.Models.Lesson", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Schedule.Models.Teacher", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
