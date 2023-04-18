using Microsoft.AspNetCore.Identity;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Services;

public class AuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task<bool> FindUserAsync(AppUser user)
    {
        return !string.IsNullOrEmpty(await _userManager.GetUserNameAsync(user));
    }

    public async Task<bool> RegisterAsync(UserRegistrationModel model)
    {
        AppUser user = model;

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "user");

            var address = await _addressService.GetOrCreateAsync(model);
            await _addressService.AddAddressAsync(user, address);

            return true;
        }

        return false;
    }
}
