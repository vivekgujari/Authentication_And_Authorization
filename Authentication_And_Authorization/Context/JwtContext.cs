using Authentication_And_Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_And_Authorization.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
