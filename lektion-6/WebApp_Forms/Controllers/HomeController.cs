using Microsoft.AspNetCore.Mvc;
using WebApp_Forms.Models.Forms;

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
        public IActionResult Index(UserRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return View();


            return View();

        }
    }
}
