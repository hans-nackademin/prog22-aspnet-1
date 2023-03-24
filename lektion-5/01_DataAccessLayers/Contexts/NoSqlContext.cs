using _01_DataAccessLayers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_DataAccessLayers.Contexts
{
    public class NoSqlContext : DbContext
    {
        public NoSqlContext(DbContextOptions<NoSqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToContainer("Products")
                .HasPartitionKey(x => x.ArticleNumber);
        }

        public DbSet<ProductEntity> Products { get; set;}
    }
}
