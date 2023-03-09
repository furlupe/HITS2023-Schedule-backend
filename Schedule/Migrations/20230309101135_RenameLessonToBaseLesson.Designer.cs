﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Schedule.Utils;

#nullable disable

namespace Schedule.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230309101135_RenameLessonToBaseLesson")]
    partial class RenameLessonToBaseLesson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupLesson", b =>
                {
                    b.Property<int>("GroupsNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupsNumber", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("GroupLesson");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");

                    b.HasData(
                        new
                        {
                            RolesId = new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"),
                            UsersId = new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9")
                        });
                });

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

                    b.HasData(
                        new
                        {
                            Number = 101,
                            Name = "Cabinet No. 101"
                        },
                        new
                        {
                            Number = 102,
                            Name = "Cabinet No. 102"
                        },
                        new
                        {
                            Number = 103,
                            Name = "Cabinet No. 103"
                        });
                });

            modelBuilder.Entity("Schedule.Models.Group", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.HasKey("Number");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Number = 972103
                        },
                        new
                        {
                            Number = 972203
                        });
                });

            modelBuilder.Entity("Schedule.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CabinetNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CabinetNumber");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Schedule.Models.LessonScheduled", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BaseLessonId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("TimeslotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BaseLessonId");

                    b.HasIndex("TimeslotId");

                    b.ToTable("ScheduledLessons");
                });

            modelBuilder.Entity("Schedule.Models.RefreshToken", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Value");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Schedule.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f00a541-b9f1-441f-a1b3-bfdb408afcf0"),
                            Value = 0
                        },
                        new
                        {
                            Id = new Guid("e4bbd429-cab4-4741-914d-f868a0e51b96"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("e48a219e-e730-4426-abd3-b5ba31e6dea5"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("f75fd0be-f94d-4966-9288-cbbf2efd9a36"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"),
                            Value = 4
                        });
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

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a5a03a62-09db-4e29-b3d8-b5a4db4ed34d"),
                            Name = "Albebra"
                        },
                        new
                        {
                            Id = new Guid("c9a6e332-46ae-41a0-bf5e-e1ff058f11e9"),
                            Name = "English language"
                        },
                        new
                        {
                            Id = new Guid("48f21452-ef29-4703-8906-7daebd7a9c3f"),
                            Name = "Programming"
                        },
                        new
                        {
                            Id = new Guid("afefed60-dad4-4b7b-8003-17960eeada5d"),
                            Name = "Amogusing"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("31734aa4-00aa-42f0-8b60-93eab68c4b7d"),
                            Name = "Amogus Ballser"
                        },
                        new
                        {
                            Id = new Guid("0c691990-d467-4984-b1c6-34ad6025b640"),
                            Name = "Name Name Teacher"
                        });
                });

            modelBuilder.Entity("Schedule.Models.Timeslot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeOnly>("EndsAt")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("StartsAt")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("Timeslots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0260f3c9-a031-4cf5-9fae-4c097655f375"),
                            EndsAt = new TimeOnly(10, 20, 0),
                            StartsAt = new TimeOnly(8, 45, 0)
                        },
                        new
                        {
                            Id = new Guid("9c2c48ef-6fb9-468b-91cb-654566540bf4"),
                            EndsAt = new TimeOnly(12, 10, 0),
                            StartsAt = new TimeOnly(10, 35, 0)
                        },
                        new
                        {
                            Id = new Guid("ffde25f3-98e7-4856-aa50-4497af87f52d"),
                            EndsAt = new TimeOnly(14, 0, 0),
                            StartsAt = new TimeOnly(12, 25, 0)
                        });
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

                    b.Property<Guid?>("TeacherProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupNumber");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("TeacherProfileId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9"),
                            Login = "furlupe",
                            Password = "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB"
                        });
                });

            modelBuilder.Entity("GroupLesson", b =>
                {
                    b.HasOne("Schedule.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Schedule.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("Cabinet");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Schedule.Models.LessonScheduled", b =>
                {
                    b.HasOne("Schedule.Models.Lesson", "BaseLesson")
                        .WithMany()
                        .HasForeignKey("BaseLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Timeslot", "Timeslot")
                        .WithMany()
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseLesson");

                    b.Navigation("Timeslot");
                });

            modelBuilder.Entity("Schedule.Models.RefreshToken", b =>
                {
                    b.HasOne("Schedule.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("Schedule.Models.Teacher", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
