using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthService _auth;

    public AuthenticationController(AuthService auth)
    {
        _auth = auth;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(AuthenticationRegistrationModel model)
    {
        if(ModelState.IsValid)
        {
            if(await _auth.RegisterAsync(model))
                return Created("", null);
        }

        return BadRequest();
    }


    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(AuthenticationLoginModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await _auth.LoginAsync(model);
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
        }

        return Unauthorized("Incorrect email or password");
    }
}
