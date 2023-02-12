using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics;

namespace DataLayer
{
    internal class JobManagementContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<ArticleGroupEntity> ArticleGroups { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<CustomerEntity>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Customers)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<LocationEntity>()
                .HasKey(l => l.LocationId);

            modelBuilder.Entity<ArticleEntity>()
                .HasKey(a => a.ArticleId);

            modelBuilder.Entity<ArticleEntity>()
                .HasOne(a => a.ArticleGroup)
                .WithMany(ag => ag.Articles)
                .HasForeignKey(a => a.ArticleGroupId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ArticleGroupEntity>()
                .HasKey(ag => ag.ArticleGroupId);

            modelBuilder.Entity<ArticleGroupEntity>()
                .HasOne(ag => ag.SuperiorArticleGroup)
                .WithMany(ag => ag.SubordinateArticleGroups)
                .HasForeignKey(ag => ag.SuperiorArticleGroupId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


            modelBuilder.Entity<PositionEntity>()
                .HasKey(p => p.PositionId);

            modelBuilder.Entity<PositionEntity>()
                .HasOne(p => p.Article)
                .WithMany(a => a.Positions)
                .HasForeignKey(p => p.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PositionEntity>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Positions)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<OrderEntity>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


            AddSampleData();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLSERVER_EB;Database=JobManagementTest;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");
            // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
            optionsBuilder.UseLazyLoadingProxies();
        }

        private void AddSampleData()
        {
            
        }
    }
}
