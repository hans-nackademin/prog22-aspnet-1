using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthManager _authManager;

        public AuthenticationController(AuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserSchema schema)
        {
            if(ModelState.IsValid)
            {
                if (await _authManager.RegisterAsync(schema))
                    return Created("", null!);
            }

            return BadRequest();
        }
    }
}
