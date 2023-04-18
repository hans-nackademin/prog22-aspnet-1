using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;
using WebApi.Helpers;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
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
        try
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == model.Email))
                    return Conflict(model);

                if (await _auth.RegisterAsync(model))
                    return Created("", null);
            }

            return BadRequest(model);
        }
        catch {  return Problem(); }
    }



    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var token = await _auth.LoginAsync(model);
                if (!string.IsNullOrEmpty(token))
                    return Ok(token);

                ModelState.AddModelError("", "Incorrect email or password");
                return Unauthorized(model);
            }

            return BadRequest(model);
        }
        catch { return Problem(); }
    }
}
