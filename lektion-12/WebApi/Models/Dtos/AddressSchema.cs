using WebApi.Helpers.Factories;
using WebApi.Models.Entities;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos
{
    public class AddressSchema : IAddressSchema
    {
        public string AddressLine_1 { get; set; } = null!;
        public string? AddressLine_2 { get; set;}
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public static implicit operator AddressEntity(AddressSchema schema) 
            => AddressEntityFactory.Create(schema);
    }
}
