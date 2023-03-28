using Microsoft.AspNetCore.Mvc;
using WebApp_Forms.Models.Forms;
using WebApp_Forms.Shared.Models;
using WebApp_Forms.Shared.Services;

namespace WebApp_Forms.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return View();


            await _userService.CreateAsync(new User
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City

            }, form.Password!);
            
            return RedirectToAction("Index");

        }
    }
}
