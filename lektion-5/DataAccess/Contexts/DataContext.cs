using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    internal class DataContext : DbContext
    {
        #region constructors & overrides
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Education\PROG22\aspnet-1\lektion-5\DataAccess\Data\mssql-dataaccess.mdf;Integrated Security=True;Connect Timeout=30");
        }
        #endregion

        public DbSet<ProductEntity> Products { get; set; }
    }
}
