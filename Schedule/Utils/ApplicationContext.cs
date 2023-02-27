using Microsoft.EntityFrameworkCore;
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
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "furlupe",
                    Password = Credentials.EncodePassword("ilikehex"),
                    Role = Enums.Role.ROOT,
                    TeacherProfile = null,
                    Group = null
                });
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    Number = 972103
                },
                new Group
                {
                    Number = 972201
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
