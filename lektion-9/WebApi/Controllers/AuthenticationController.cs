using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebApi.Models.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }





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


    [Route("SignIn")]
    [HttpPost]
    public async Task<IActionResult> SignIn()
    {
        if (ModelState.IsValid)
        {
            return Ok();
        }

        return BadRequest("Incorrect email or password");
    }
}
