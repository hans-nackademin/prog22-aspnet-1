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


    public async Task AddAsync()
    {
        await _addressRepo.CreateAsync(new AddressEntity());
        await _userRepo.CreateAsync(new UserEntity());

    }

}
