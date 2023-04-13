using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class UserProfileRepository : Repository<UserProfileEntity>
{
    private readonly IdentityContext _identityContext;

    public UserProfileRepository(IdentityContext identity) : base(identity)
    {
        _identityContext = identity;
    }

    public async Task<bool> AddAddressAsync(UserProfileEntity userProfileEntity, AddressEntity addressEntity)
    {
        try
        {
            userProfileEntity.Addresses.Add(addressEntity);

            _identityContext.Update(userProfileEntity);
            await _identityContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public override async Task<IEnumerable<UserProfileEntity>> GetAllAsync()
    {
        return await _identityContext.UserProfiles
            .Include(x => x.User)
            .Include(x => x.Addresses)
            .ToListAsync();
    }
}
