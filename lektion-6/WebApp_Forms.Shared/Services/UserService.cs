using WebApp_Forms.Shared.Models;
using WebApp_Forms.Shared.Models.Entities;
using WebApp_Forms.Shared.Repositories;

namespace WebApp_Forms.Shared.Services;

public class UserService
{
    private readonly UserRepository _userRepo;
    private readonly AddressRepository _addressRepo;

    public UserService(UserRepository userRepo, AddressRepository addressRepo)
    {
        _userRepo = userRepo;
        _addressRepo = addressRepo;
    }


    public async Task<User> CreateAsync(User model, string password)
    {
        var addressEntity = await _addressRepo.GetAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode);
        addressEntity ??= await _addressRepo.CreateAsync(new AddressEntity
        {
            StreetName = model.StreetName!,
            PostalCode = model.PostalCode!,
            City = model.City!,
        });

        var userEntity = await _userRepo.CreateAsync(new UserEntity
        {
            FirstName = model.FirstName!,
            LastName = model.LastName!,
            Email = model.Email!,
            Password = password,
            AddressId = addressEntity.Id
        });
        
        model.Id = userEntity.Id;
        return model;
    }

}
