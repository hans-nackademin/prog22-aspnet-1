using _01_DataAccessLayers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_DataAccessLayers.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
