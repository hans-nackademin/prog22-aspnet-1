using System.ComponentModel.DataAnnotations;
using WebApi.Models.Identity;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos
{
    public class UserLoginModel : IAuthenticationInformation
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        public static implicit operator AppUser(UserLoginModel model)
        {
            return new AppUser
            {
                UserName = model.Email,
                Email = model.Email
            };
        }
    }
}
