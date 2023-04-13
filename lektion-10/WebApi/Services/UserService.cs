using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class UserService
{
    private readonly UserProfileRepository _userProfileRepository;

    public UserService(UserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<IEnumerable<UserProfileEntity>> GetAllAsync()
    {
        return await _userProfileRepository.GetAllAsync();
    }
}
