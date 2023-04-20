using Microsoft.AspNetCore.Identity;
using WebApi.Helpers.Factories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Helpers.Services
{
    public class AuthManager
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly AddressManager _addressManager;

        public AuthManager(UserManager<CustomIdentityUser> userManager, AddressManager addressManager)
        {
            _userManager = userManager;
            _addressManager = addressManager;
        }

        public async Task<bool> RegisterAsync(UserSchema userSchema)
        {
            CustomIdentityUser customIdentityUser = userSchema;
            var result = await _userManager.CreateAsync(customIdentityUser, userSchema.Password);           
            
            if (result.Succeeded)
            {
                await _addressManager.AddUserAddressAsync(UserAddressEntityFactory.Create(
                    customIdentityUser.Id, 
                    (await _addressManager.GetOrCreateAsync(userSchema.Address)).Id
                ));
                return true;
            }

            return false;
        }
    }
}
