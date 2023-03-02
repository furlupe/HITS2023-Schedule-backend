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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Groups)
                .WithMany();

            modelBuilder.Entity<Group>().HasData(
                new Group { Number = 972103 },
                new Group { Number = 972203 }
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
                Login = Environment.GetEnvironmentVariable("ROOT_USERNAME"), 
                Password = Credentials.EncodePassword(
                    Environment.GetEnvironmentVariable("ROOT_PASSWORD")
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
