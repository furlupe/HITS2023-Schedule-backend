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
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BlacklistedToken> Blacklist { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var rootRole = new Role { Id = Guid.NewGuid(), Value = RoleEnum.ROOT };

            modelBuilder.Entity<Group>().HasData(
                new Group { Number = 972103},
                new Group { Number = 972203 }
                );

            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.STUDENT},
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.TEACHER },
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.EDITOR },
                    new Role { Id = Guid.NewGuid(), Value = RoleEnum.ADMIN },
                    rootRole
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
