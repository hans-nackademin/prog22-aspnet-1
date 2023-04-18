using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserService _userService;

    public AuthenticationController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _userService.CheckIfUserExistsAsync(model))
                return Conflict(model);
            
            if (await _userService.CreateUserAsync(model))
                return Created("", null);
        }

        return BadRequest(model);
    }
}
