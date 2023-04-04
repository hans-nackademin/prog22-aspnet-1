using System.ComponentModel.DataAnnotations;
using WebApp.Models.Identity;
using WebApp.Services;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [RegularExpression(@"^[a-öA-Ö]+(?:['´-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [RegularExpression(@"^[a-öA-Ö]+(?:['´-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange en giltigt e-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Bekräfta lösenord")]
        [Required(ErrorMessage = "Du måste ange bekräfta lösenordet")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
        public string ConfirmPassword { get; set; } = null!;




        public static implicit operator AppUser(RegisterViewModel model)
        {
            return new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
        }
    }
}
