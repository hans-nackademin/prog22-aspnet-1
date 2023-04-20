namespace WebApi.Models.Interfaces
{
    public interface IAddress
    {
        public string AddressLine_1 { get; set; }
        public string? AddressLine_2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
