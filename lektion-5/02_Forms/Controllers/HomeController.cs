using Microsoft.AspNetCore.Mvc;

namespace _02_Forms.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
