using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;

    public UserService(UserManager<AppUser> userManager, AddressService addressService)
    {
        _userManager = userManager;
        _addressService = addressService;
    }

    public async Task<bool> CheckIfUserExistsAsync(AppUser user)
    {
        return !string.IsNullOrEmpty(await _userManager.GetUserNameAsync(user));
    }

    public async Task<bool> CreateUserAsync(UserRegistrationModel model)
    {

        AppUser user = model;

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var address = await _addressService.GetOrCreateAsync(model);

            return true;
        }

        return false;
    }
}
