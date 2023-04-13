using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext identity) : base(identity)
    {
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity entity)
    {
        var addressEntity = await GetAsync(x => x.StreetName == entity.StreetName && x.PostalCode == entity.PostalCode && x.City == entity.City);
        addressEntity ??= await AddAsync(entity);
    
        return addressEntity;
    }

}
