using Microsoft.EntityFrameworkCore;

namespace UserRepoApp.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):
            base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
