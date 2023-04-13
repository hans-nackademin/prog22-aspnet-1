using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
    private readonly IdentityContext _identityContext;

    public AddressRepository(IdentityContext identity) : base(identity)
    {
        _identityContext = identity;
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity entity)
    {
        var addressEntity = await GetAsync(x => x.StreetName == entity.StreetName && x.PostalCode == entity.PostalCode && x.City == entity.City);
        addressEntity ??= await AddAsync(entity);
    
        return addressEntity;
    }

    public async Task<bool> PairUserProfileAndAddress(string userId, int addressId)
    {
        try
        {
            await _identityContext.Addresses.
            return true;
        }
        catch { return false; }

    }
}
