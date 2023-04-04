using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class LoginViewModel
{

    [Display(Name = "E-postadress")]
    [Required(ErrorMessage = "Du måste ange en e-postadress")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Lösenord")]
    [Required(ErrorMessage = "Du måste ange ett lösenord")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

}
