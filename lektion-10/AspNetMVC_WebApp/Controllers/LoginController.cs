using AspNetMVC_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC_WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                using var http = new HttpClient();

                var result = await http.PostAsJsonAsync("https://localhost:7032/api/authentication/login", viewModel);
                var token = await result.Content.ReadAsStringAsync();

                HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(1)
                });

                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Incorrect email or password");

            return View(viewModel);
        }
    }
}
