using WebApi.Helpers.Factories;
using WebApi.Models.Entities;
using WebApi.Models.Identity;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos
{
    public class UserSchema 
    { 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AddressSchema Address { get; set; } = null!;

        public static implicit operator CustomIdentityUser(UserSchema schema) => CustomIdentityUserFactory.Create(schema);
    }
}
