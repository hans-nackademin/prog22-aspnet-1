using System.ComponentModel.DataAnnotations;
using WebApp.Factories;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";

        public static implicit operator CustomIdentityUser(SignInViewModel model)
        {
            var user = CustomIdentityUserFactory.Create(model.Email);
            return user;
        }
    }
}
