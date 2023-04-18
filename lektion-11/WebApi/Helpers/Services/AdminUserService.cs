using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Services;

public class AdminUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;
    private readonly SignInManager<AppUser> _signInManager;

    public AdminUserService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task<bool> CreateAsync(UserCreateModel model)
    {
        AppUser user = model;

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "user");
            return true;
        }

        return false;
    }


}
