using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [UseApiKey]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string>
            {
                "Product 1", "Product 2", "Product 3"
            });
        }
    }
}
