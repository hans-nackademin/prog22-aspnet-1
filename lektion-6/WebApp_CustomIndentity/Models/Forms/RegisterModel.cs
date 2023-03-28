using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_CustomIndentity.Models.Forms
{
    public class RegisterModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";
    }
}
