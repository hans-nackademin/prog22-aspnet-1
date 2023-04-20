using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        return await _userManager.Users.AnyAsync(x => x.Email == user.Email);
    }

    public async Task<bool> RegisterAsync(UserRegistrationModel model)
    {
        AppUser user = model;

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            //await _userManager.AddToRoleAsync(user, "user");

            var address = await _addressService.GetOrCreateAsync(model);
            await _addressService.AddAddressAsync(user, address);

            return true;
        }

        return false;
    }

    public async Task<string> LoginAsync(UserLoginModel model)
    {
        var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (userEntity != null)
            if (await _userManager.CheckPasswordAsync(userEntity, model.Password))
                return TokenGenerator.Generate(await _userManager.GetClaimsAsync(model), DateTime.Now.AddHours(1));

        return null!;
    }
}
