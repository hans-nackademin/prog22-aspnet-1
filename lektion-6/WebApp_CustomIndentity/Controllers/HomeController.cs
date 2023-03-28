using Microsoft.AspNetCore.Mvc;

namespace WebApp_CustomIndentity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
