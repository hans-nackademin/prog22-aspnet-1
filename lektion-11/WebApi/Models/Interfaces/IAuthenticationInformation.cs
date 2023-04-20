namespace WebApi.Models.Interfaces;

public interface IAuthenticationInformation
{
    string Email { get; set; }
    string Password { get; set; }
}
