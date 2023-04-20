using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepository;
    private readonly UserAddressRepository _userAddressRepository;

    public AddressService(AddressRepository addressRepository, UserAddressRepository userAddressRepository)
    {
        _addressRepository = addressRepository;
        _userAddressRepository = userAddressRepository;
    }

    public async Task<Address> GetOrCreateAsync(AddressEntity addressEntity)
    {
        var entity = await _addressRepository.GetAsync(x => 
            x.StreetName == addressEntity.StreetName &&
            x.PostalCode == addressEntity.PostalCode &&
            x.City == addressEntity.City        
        );

        entity ??= await _addressRepository.AddAsync(addressEntity);
        return entity;
    }

    public async Task AddAddressAsync(User user, Address address)
    {
        await _userAddressRepository.AddAsync(new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = address.Id,
        });
    }
}
