using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
