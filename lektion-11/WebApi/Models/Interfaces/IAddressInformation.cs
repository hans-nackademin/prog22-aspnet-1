namespace WebApi.Models.Interfaces;

public interface IAddressInformation
{
    string StreetName { get; set; }
    string PostalCode { get; set; }
    string City { get; set; }
    string Country { get; set; }
}
