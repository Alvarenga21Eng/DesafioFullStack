using DesafioFullStack.Data.Map;
using DesafioFullStack.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions<SystemDBContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
