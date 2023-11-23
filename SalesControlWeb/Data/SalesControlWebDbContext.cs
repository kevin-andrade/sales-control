using Microsoft.EntityFrameworkCore;

namespace SalesControlWeb.Models
{
    public class SalesControlWebDbContext : DbContext
    {
        public SalesControlWebDbContext(DbContextOptions<SalesControlWebDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
    }
}
