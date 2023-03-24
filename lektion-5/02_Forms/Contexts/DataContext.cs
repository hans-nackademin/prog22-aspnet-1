using _02_Forms.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_Forms.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
