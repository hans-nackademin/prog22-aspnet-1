using WebApi.Models.Entities;

namespace WebApi.Helpers.Factories
{
    public class UserAddressEntityFactory
    {
        public static UserAddressEntity Create() => new();
        public static UserAddressEntity Create(string userId, int addressId) => new()
        {
            UserId = userId,
            AddressId = addressId
        };
    }
}
