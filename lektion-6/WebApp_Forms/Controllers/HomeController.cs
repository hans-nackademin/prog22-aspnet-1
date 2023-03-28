using Microsoft.AspNetCore.Mvc;

namespace WebApp_Forms.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string something)
        {
            return View();
        }


    }
}
