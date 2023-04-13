// Import the necessary namespaces for working with ASP.NET Core Identity and Data Annotations
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

// Define the namespace for the AuthenticationRegistrationModel class
namespace WebApi.Models.DTO;

// Create the AuthenticationRegistrationModel class, which represents a user registration request
public class AuthenticationRegistrationModel
{
    // User's first name
    public string FirstName { get; set; } = null!;

    // User's last name
    public string LastName { get; set; } = null!;

    // User's email address with a regular expression attribute to validate the email format
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; } = null!;

    // User's password with a regular expression attribute to enforce a strong password policy
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = null!;

    // Optional user's phone number
    public string? PhoneNumber { get; set; }

    // Optional user's street name for the address
    public string? StreetName { get; set; }

    // Optional user's postal code for the address
    public string? PostalCode { get; set; }

    // Optional user's city for the address
    public string? City { get; set; }

    // Implicit conversion from AuthenticationRegistrationModel to IdentityUser
    public static implicit operator IdentityUser(AuthenticationRegistrationModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

    // Implicit conversion from AuthenticationRegistrationModel to UserProfileEntity
    public static implicit operator UserProfileEntity(AuthenticationRegistrationModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }

    // Implicit conversion from AuthenticationRegistrationModel to AddressEntity
    public static implicit operator AddressEntity(AuthenticationRegistrationModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName!,
            PostalCode = model.PostalCode!,
            City = model.City!
        };
    }
}

