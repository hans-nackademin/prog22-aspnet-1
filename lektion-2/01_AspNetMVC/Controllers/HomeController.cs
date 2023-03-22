using Microsoft.AspNetCore.Mvc;

namespace _01_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
