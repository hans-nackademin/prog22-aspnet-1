using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;
using WebApi.Models.Identity;

namespace WebApi.Controllers
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize]
    [UseApiKey]
    public class AdminUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }
    }
}
