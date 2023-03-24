using System.ComponentModel.DataAnnotations;

namespace _02_Forms.Models.Forms
{
    public class CustomerRegistratonForm
    {
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [MinLength(2, ErrorMessage = "Förnamnet måste minst innehålla 2 tecken")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [MinLength(3, ErrorMessage = "Efternamnet måste minst innehålla 2 tecken")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [MinLength(2, ErrorMessage = "E-postadressen måste minst innehålla 2 tecken")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Lösenordet måste minst innehålla 8 tecken")]
        public string Password { get; set; } = null!;
    }
}
