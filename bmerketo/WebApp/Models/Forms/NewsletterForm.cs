using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Forms
{
    public class NewsletterForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
