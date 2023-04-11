using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    #region Constructors & Private Fields

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AuthService _auth;

    public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AuthService auth)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _auth = auth;
    }

    #endregion

    #region SignUp

    [Route("SignUp")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userManager.CreateAsync(model, model.Password);
            
            if (result.Succeeded)
                return Created("", null);
            else
                return BadRequest(result.Errors);
        }

        return BadRequest(model);
    }

    #endregion

    #region SignIn

    [Route("SignIn")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await _auth.SignInAsync(model.Email, model.Password); 
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
        }

        return Unauthorized("Incorrect email or password");
    }

    #endregion

    #region SignOut

    [Route("SignOut")]
    [HttpPost]
    public async Task<IActionResult> SignOut()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        return Unauthorized();
    }

    #endregion
}
