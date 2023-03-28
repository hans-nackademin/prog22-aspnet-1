using System.ComponentModel.DataAnnotations;

namespace WebApp_Forms.Models.Forms
{
    public class UserRegistrationForm
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
