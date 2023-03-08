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
    [Migration("20230308121811_Minor")]
    partial class Minor
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
                            RolesId = new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"),
                            UsersId = new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15")
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

                    b.Property<DateOnly>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateUntil")
                        .HasColumnType("date");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TimeslotId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CabinetNumber");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimeslotId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Schedule.Models.LessonScheduled", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TimeslotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

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
                            Id = new Guid("a89729b9-e13b-4964-8ace-e538bc073047"),
                            Value = 0
                        },
                        new
                        {
                            Id = new Guid("21fcd0f4-fabb-4531-bcc7-37a2afee0d83"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("f8f132ad-edb0-43d5-9629-95d63ec20090"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("3a059f41-554e-4c4f-997b-92b5bb418ac2"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"),
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
                            Id = new Guid("a4328591-51ab-4f62-9cf1-41c2356cdf01"),
                            Name = "Albebra"
                        },
                        new
                        {
                            Id = new Guid("ef9be43b-7f98-4710-8a24-3ca884196e82"),
                            Name = "English language"
                        },
                        new
                        {
                            Id = new Guid("698a5139-2222-4bcb-b9f2-9a4fc4d854c0"),
                            Name = "Programming"
                        },
                        new
                        {
                            Id = new Guid("493eff5f-764d-4e98-8ee1-c5e93bd8892c"),
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
                            Id = new Guid("08f7c0f1-7c61-45c5-8737-f63a1ce1edd2"),
                            Name = "Amogus Ballser"
                        },
                        new
                        {
                            Id = new Guid("6c530c89-27bd-4512-87f6-7bde4289443c"),
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
                            Id = new Guid("542afc28-b50d-431b-bc1b-a4a196b6ed02"),
                            EndsAt = new TimeOnly(10, 20, 0),
                            StartsAt = new TimeOnly(8, 45, 0)
                        },
                        new
                        {
                            Id = new Guid("f4ac522a-433f-4ae1-bd22-bc3eb1d04854"),
                            EndsAt = new TimeOnly(12, 10, 0),
                            StartsAt = new TimeOnly(10, 35, 0)
                        },
                        new
                        {
                            Id = new Guid("d03a832d-03c4-4771-ba0b-eb7bb6273a57"),
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
                            Id = new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15"),
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

            modelBuilder.Entity("Schedule.Models.LessonScheduled", b =>
                {
                    b.HasOne("Schedule.Models.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule.Models.Timeslot", "Timeslot")
                        .WithMany()
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

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
