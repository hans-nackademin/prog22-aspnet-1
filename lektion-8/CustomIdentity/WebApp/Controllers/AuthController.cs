using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private SignUpViewModel _signUpViewModel;

        public AuthController(SignUpViewModel signUpViewModel)
        {
            _signUpViewModel = signUpViewModel;
        }

        public IActionResult SignUp(string returnUrl = null!)
        {
            _signUpViewModel.ReturnUrl = returnUrl ?? Url.Content("/");
            return View(_signUpViewModel);
        }
    }
}
