using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataProvider
{
    internal class JobManagementDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<ArticleGroupEntity> ArticleGroups { get; set; }

        public DbSet<HierarcicalArticleGroupEntity> HirarcicalArticleGroups { get; set; }
        public DbSet<OrderEvaluationEntity> OrderEvaluationEntities { get; set; }
        public DbSet<Customer> FilteredCustomers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var locationModelBuilder = modelBuilder.Entity<AddressEntity>()
                .ToTable("Address", b => b.IsTemporal());

            var customerModelBuilder = modelBuilder.Entity<CustomerEntity>()
                .ToTable("Customer");

            var orderModelBuilder = modelBuilder.Entity<OrderEntity>()
                .ToTable("Order");

            var positionModelBuilder = modelBuilder.Entity<PositionEntity>()
                .ToTable("Position");

            var articleModelBuilder = modelBuilder.Entity<ArticleEntity>()
                .ToTable("Article");

            var articleGroupModelBuilder = modelBuilder.Entity<ArticleGroupEntity>()
                .ToTable("ArticleGroup");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLSERVER_EB;Database=JobManagementTest;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");
            // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}