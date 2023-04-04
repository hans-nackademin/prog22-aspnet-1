using Microsoft.AspNetCore.Identity;
using WebApp.Models.Identity;

namespace WebApp.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task<bool> CreateUserAccountAsync(AppUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
            return true;

        return false;

    }

    public async Task<bool> SignInAsync(AppUser user, string password)
    {
        var signedIn = await _signInManager.PasswordSignInAsync(user, password, false, false);
        if (signedIn.Succeeded)
            return true;

        return false;
    }
}
