using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using WebApp.Factories;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Bekräfta Lösenord")]
        [Required(ErrorMessage = "Du måste ange bekräfta lösenordet")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
        public string ConfirmPassword { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";

        public static implicit operator CustomIdentityUser(SignUpViewModel model)
        {
            var user = CustomIdentityUserFactory.Create(model.Email);         
            return user;
        }
    }
}
