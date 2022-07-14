using CraftMake.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftMake.Context
{
    public class CraftMakeDatabaseContext : DbContext
    {
        public CraftMakeDatabaseContext(DbContextOptions<CraftMakeDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
