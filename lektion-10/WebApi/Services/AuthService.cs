using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WebApi.Helpers;
using WebApi.Models.DTO;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class AuthService
{
    private readonly UserProfileRepository _userProfileRepository;
    private readonly AddressRepository _addressRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtToken _jwt;

    public AuthService(UserProfileRepository userProfileRepository, AddressRepository addressRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtToken jwt)
    {
        _userProfileRepository = userProfileRepository;
        _addressRepository = addressRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwt = jwt;
    }

    public async Task<bool> RegisterAsync(AuthenticationRegistrationModel model)
    {
        try
        {
            // 1. Skapa en Identity User
            var identityResult = await _userManager.CreateAsync(model, model.Password);
            if (identityResult.Succeeded)
            {
                var identityUser = await _userManager.FindByEmailAsync(model.Email);

                // 3. Skapa en Användarprofil
                UserProfileEntity userProfileEntity = model;
                userProfileEntity.UserId = identityUser!.Id;
                await _userProfileRepository.AddAsync(userProfileEntity);

                // 4. Skapa en adress om den inte finns
                var addressEntity = await _addressRepository.GetOrCreateAsync(model);

                // 5. Lägg till adressassociationen
                await _userProfileRepository.AddAddressAsync(userProfileEntity, addressEntity);

                return true;
            }
        
        } catch { }

        return false;
    }

    public async Task<string> LoginAsync(AuthenticationLoginModel model)
    {
        var identityUser = await _userManager.FindByEmailAsync(model.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
            if (signInResult.Succeeded)
            {
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, identityUser.Email!)
                });

                return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
            }

        }

        return string.Empty;
    }
}
