using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;

public class SignUpModel
{
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]
    public string LastName { get; set; } = null!;

    [Required]
    [MinLength(6)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; } = null!;
    
    [Required]
    [MinLength(8)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = null!;
    
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }   
    

    public static implicit operator IdentityUser(SignUpModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email
        };
    }
}
