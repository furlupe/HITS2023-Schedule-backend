using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Utils
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BlacklistedToken> Blacklist { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
