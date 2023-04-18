using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;
using WebApi.Models.Identity;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos;

public class UserRegistrationModel : IProfileInformation, IAddressInformation, IAuthenticationInformation
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public string CompanyName { get; set; }

    [Required]
    public string StreetName { get; set; }
    
    [Required]
    public string PostalCode { get; set; }
    
    [Required]
    public string City { get; set; }
    public string Country { get; set; }
    
    [Required]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; }
    
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }


    public static implicit operator AppUser(UserRegistrationModel model)
    {
        return new AppUser
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.CompanyName
        };
    }

    public static implicit operator AddressEntity(UserRegistrationModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
            Country = model.Country
        };
    }
}
