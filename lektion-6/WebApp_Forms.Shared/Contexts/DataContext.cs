using Microsoft.EntityFrameworkCore;

namespace WebApp_Forms.Shared.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}
