using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserService _userService;

        public RegisterController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = viewModel;
               
                if (await _userService.CreateUserAccountAsync(appUser, viewModel.Password))
                {
                    if (await _userService.SignInAsync(appUser, viewModel.Password))
                        return RedirectToAction("Index", "Account");

                    return RedirectToAction("Index", "Login");
                }

                ModelState.AddModelError("", "Något gick fel vid registreringen av användaren");
            }

            return View(viewModel);
        }
    }
}
