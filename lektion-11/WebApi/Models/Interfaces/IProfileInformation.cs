namespace WebApi.Models.Interfaces;

public interface IProfileInformation
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string CompanyName { get; set; }
}
