using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WebApi.Helpers;

namespace WebApi.Services;

public class AuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> SignInAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

        if (result.Succeeded)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (identityUser != null)
            {
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, identityUser.Email!)
                });

                return TokenGenerator.GenerateJwtToken(claimsIdentity, DateTime.Now.AddHours(1), _configuration.GetValue<string>("SecretKey")!);
            }
        }

        return null!;
    
    }
}
