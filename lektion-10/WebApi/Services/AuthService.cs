using Microsoft.AspNetCore.Identity;
using WebApi.Models.DTO;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class AuthService
{
    private readonly UserProfileRepository _userProfileRepository;
    private readonly AddressRepository _addressRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(UserProfileRepository userProfileRepository, AddressRepository addressRepository, UserManager<IdentityUser> userManager)
    {
        _userProfileRepository = userProfileRepository;
        _addressRepository = addressRepository;
        _userManager = userManager;
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
}
