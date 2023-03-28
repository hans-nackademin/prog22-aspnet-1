using Microsoft.EntityFrameworkCore;
using WebApp_Forms.Shared.Models.Entities;

namespace WebApp_Forms.Shared.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
}
