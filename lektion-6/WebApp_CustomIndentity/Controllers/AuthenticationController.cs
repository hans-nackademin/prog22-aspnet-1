using Microsoft.AspNetCore.Mvc;
using WebApp_CustomIndentity.Models.Forms;
using WebApp_CustomIndentity.Services;

namespace WebApp_CustomIndentity.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AuthService _auth;

        public AuthenticationController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Register(string returnUrl = null!)
        {
            var form = new RegisterModel();

            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel form)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.RegisterAsync(form))
                {
                    if (await _auth.LoginAsync(form.Email, form.Password))
                        return LocalRedirect(form.ReturnUrl);
                    else 
                        return RedirectToAction("Login", "Authentication");
                }

                ModelState.AddModelError(string.Empty, "Unable to create an account. Please contact customer support.");
            }

            return View();
        }

    }
}
