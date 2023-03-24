using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
