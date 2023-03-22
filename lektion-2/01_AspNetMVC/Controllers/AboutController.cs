using Microsoft.AspNetCore.Mvc;

namespace _01_AspNetMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
