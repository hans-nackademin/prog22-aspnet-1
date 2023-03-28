using System.ComponentModel.DataAnnotations;

namespace WebApp_Forms.Models.Forms
{
    public class UserRegistrationForm
    {
        [Required(ErrorMessage = "You must enter your first name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = null!;

        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
