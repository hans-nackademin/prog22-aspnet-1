using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos;

public class Address : IAddressInformation
{
    public int Id { get; set; }
    public string StreetName { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
