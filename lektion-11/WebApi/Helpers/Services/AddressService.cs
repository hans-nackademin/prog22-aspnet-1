using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class AddressService
{
    public async Task<Address> GetOrCreateAsync(AddressEntity addressEntity)
    {
        return addressEntity;
    }
}
