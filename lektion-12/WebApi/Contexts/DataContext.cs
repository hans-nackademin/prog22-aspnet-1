using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Contexts
{
    public class DataContext : IdentityDbContext<CustomIdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }
        public DbSet<CompanyEntity> AspNetCompanies { get; set; }
        public DbSet<UserCompanyEntity> AspNetUserCompanies { get; set; }
    }

    
}
