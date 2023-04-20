using Microsoft.AspNetCore.Identity;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Factories
{
    public class CustomIdentityUserFactory
    {
        public static CustomIdentityUser Create(string email) 
        {
            var passwordHasher = new PasswordHasher<CustomIdentityUser>();
            var user = new CustomIdentityUser { Email = email, UserName = email };
            user.PasswordHash = passwordHasher.HashPassword(user, "BytMig123!");
            return user;  
        }

        public static CustomIdentityUser Create(string email, string password)
        {
            var passwordHasher = new PasswordHasher<CustomIdentityUser>();
            var user = new CustomIdentityUser { Email = email, UserName = email };
            user.PasswordHash = passwordHasher.HashPassword(user, password);
            return user;
        }

        public static CustomIdentityUser Create(UserSchema schema) => new()
        {
            UserName = schema.Email,
            FirstName = schema.FirstName,
            LastName = schema.LastName,
            Email = schema.Email,
            PhoneNumber = schema.PhoneNumber,
            ProfileImage = schema.ProfileImage
        };

        public static CustomIdentityUser Create(string firstName, string lastName, string email, string phoneNumber, string profileImage) => new()
        {
            UserName = email,
            FirstName =firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            ProfileImage = profileImage
        };
    }
}
