using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class JobManagementContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<OrderEntity>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<CustomerEntity>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLSERVER_EB;Database=JobManagementTest;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");
            // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
