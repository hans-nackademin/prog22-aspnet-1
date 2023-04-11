using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAll()
    {
        List<string> items = new List<string>()
        {
            "Product 1", "Product 2", "Product 3"
        };
        
        return Ok(items);
    }
}
