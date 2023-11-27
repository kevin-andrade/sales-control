using Microsoft.EntityFrameworkCore;

namespace SalesControlWeb.Models
{
    public class SalesControlWebDbContext : DbContext
    {
        public SalesControlWebDbContext(DbContextOptions<SalesControlWebDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
