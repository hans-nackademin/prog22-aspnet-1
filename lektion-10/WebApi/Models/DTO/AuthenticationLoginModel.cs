namespace WebApi.Models.DTO;

public class AuthenticationLoginModel
{
    // User's email address
    public string Email { get; set; } = null!;

    // User's password
    public string Password { get; set; } = null!;
}
