using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Factories
{
    public class AddressEntityFactory
    {
        public static AddressEntity Create() => new();
        public static AddressEntity Create(AddressSchema schema) => new()
        {
            AddressLine_1 = schema.AddressLine_1,
            AddressLine_2 = schema.AddressLine_2,
            PostalCode = schema.PostalCode,
            City = schema.City,
        };

    }
}
