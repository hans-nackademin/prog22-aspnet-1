// Import the necessary namespaces for working with ASP.NET Core Identity and Entity Framework Core
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

// Define the namespace for the IdentityContext class
namespace WebApi.Contexts;

// Create the IdentityContext class, which inherits from IdentityDbContext<IdentityUser>
// This class is responsible for interacting with the database for user authentication and authorization
public class IdentityContext : IdentityDbContext<IdentityUser>
{
    // Constructor for the IdentityContext class, taking DbContextOptions as a parameter
    // and passing it to the base constructor of IdentityDbContext
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    // Define the DbSet for the UserProfileEntity, which represents the UserProfiles table in the database
    public DbSet<UserProfileEntity> UserProfiles { get; set; }

    // Define the DbSet for the AddressEntity, which represents the Addresses table in the database
    public DbSet<AddressEntity> Addresses { get; set; }
}
