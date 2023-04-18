using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _auth;
    private readonly UserManager<AppUser> _userManager;


    public AuthenticationController(AuthenticationService auth, UserManager<AppUser> userManager)
    {
        _auth = auth;
        _userManager = userManager;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(await _userManager.GetUserNameAsync(model)))
                return Conflict(model);
            
            if (await _auth.RegisterAsync(model))
                return Created("", null);
        }

        return BadRequest(model);
    }



    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        if (ModelState.IsValid)
        { 
            if (await _userManager.CheckPasswordAsync(model, model.Password))
                return Ok(TokenGenerator.Generate(await _userManager.GetClaimsAsync(model), DateTime.Now.AddHours(1)));

            ModelState.AddModelError("", "Incorrect email or password");    
        }

        return BadRequest(model);
    }
}
