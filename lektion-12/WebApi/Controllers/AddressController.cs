using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressManager _addressManager;

        public AddressController(AddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddressSchema model)
        {


            return Ok(await _addressManager.GetOrCreateAsync(model));
        }
    }
}
