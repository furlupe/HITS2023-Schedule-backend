using Microsoft.EntityFrameworkCore;
using Schedule.Enums;
using Schedule.Models;

namespace Schedule.Utils
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonScheduled> ScheduledLessons { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Students)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Groups)
                .WithMany();

            modelBuilder.Entity<Timeslot>().HasData(
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(8, 45), EndsAt = new TimeOnly(10, 20)},
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(10, 35), EndsAt = new TimeOnly(12, 10) },
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(12, 25), EndsAt = new TimeOnly(14, 0) },
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(14, 45), EndsAt = new TimeOnly(16, 20) },
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(16, 35), EndsAt = new TimeOnly(18, 10) },
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(18, 25), EndsAt = new TimeOnly(20, 0) },
                new Timeslot { Id = Guid.NewGuid(), StartsAt = new TimeOnly(20, 15), EndsAt = new TimeOnly(21, 50) }
                );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = Guid.NewGuid(), Name = "Albebra"},
                new Subject { Id = Guid.NewGuid(), Name = "English language" },
                new Subject { Id = Guid.NewGuid(), Name = "Programming" },
                new Subject { Id = Guid.NewGuid(), Name = "Amogusing" },
                new Subject { Id = Guid.NewGuid(), Name = "Meth cooking" },
                new Subject { Id = Guid.NewGuid(), Name = "Russian language" },
                new Subject { Id = Guid.NewGuid(), Name = "Requirements development" },
                new Subject { Id = Guid.NewGuid(), Name = "Linear bebra" }
                );

            modelBuilder.Entity<Cabinet>().HasData(
                new Cabinet { Number = 101, Name = "Cabinet No. 101" },
                new Cabinet { Number = 102, Name = "Cabinet No. 102" },
                new Cabinet { Number = 103, Name = "Cabinet No. 103" },
                new Cabinet { Number = 211, Name = "Chill cabinet" },
                new Cabinet { Number = 222, Name = "Toilet" },
                new Cabinet { Number = 451, Name = "Denis' basement" },
                new Cabinet { Number = 333, Name = "Computer class" },
                new Cabinet { Number = 452, Name = "Hell" },
                new Cabinet { Number = 123, Name = "Sussy spaceship" },
                new Cabinet { Number = 141 },
                new Cabinet { Number = 332 },
                new Cabinet { Number = 443 }
                );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = Guid.NewGuid(), Name = "Amogus Ballser" },
                new Teacher { Id = Guid.NewGuid(), Name = "Name Name Teacher"},
                new Teacher { Id = Guid.NewGuid(), Name = "Zenis Dmeev" },
                new Teacher { Id = Guid.NewGuid(), Name = "Ilia Volgin" },
                new Teacher { Id = Guid.NewGuid(), Name = "Neel Kiggers" },
                new Teacher { Id = Guid.NewGuid(), Name = "Nuck Figgers" },
                new Teacher { Id = Guid.NewGuid(), Name = "Walter White" },
                new Teacher { Id = Guid.NewGuid(), Name = "Kid named Finger" }
                );

            modelBuilder.Entity<Group>().HasData(
                new Group { Number = 972103 },
                new Group { Number = 972203 },
                new Group { Number = 972102 },
                new Group { Number = 972202 },
                new Group { Number = 972101 },
                new Group { Number = 272201 },
                new Group { Number = 271805 },
                new Group { Number = 271905 }
                );

            var rootRole = new Role { Id = Guid.NewGuid(), Value = RoleEnum.ROOT };
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.STUDENT },
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.TEACHER },
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.EDITOR },
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.ADMIN },
                    rootRole
                );

            var root = new User { 
                Id = Guid.NewGuid(), 
                Login = "furlupe", 
                Password = Credentials.EncodePassword(
                    "ilikehex"
                    ) 
            };
            modelBuilder.Entity<User>().HasData(root);

            modelBuilder.Entity<Role>()
                .HasMany(left => left.Users)
                .WithMany(right => right.Roles)
                .UsingEntity(j => j.HasData(new { RolesId = rootRole.Id, UsersId = root.Id }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
