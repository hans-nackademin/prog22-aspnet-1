using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos;

public class User : IProfileInformation
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CompanyName { get; set; }
    public Address Address { get; set; }
    
}
