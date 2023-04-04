using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Factories;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        #region constructors

        private SignUpViewModel _signUpViewModel;
        private SignInViewModel _signInViewModel;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(SignUpViewModel signUpViewModel, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, SignInViewModel signInViewModel, RoleManager<IdentityRole> roleManager)
        {
            _signUpViewModel = signUpViewModel;
            _userManager = userManager;
            _signInManager = signInManager;
            _signInViewModel = signInViewModel;
            _roleManager = roleManager;
        }

        #endregion

        #region SignUp
        public IActionResult SignUp(string returnUrl = null!)
        {
            _signUpViewModel.ReturnUrl = returnUrl ?? Url.Content("/");
            return View(_signUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel form)
        {
            if (ModelState.IsValid)
            {
                // kontrollera om det finns roller inlagda, om inte lägg till standard roller
                if (!await _roleManager.Roles.AnyAsync())
                {
                    await _roleManager.CreateAsync(IdentityRoleFactory.Create("admin"));
                    await _roleManager.CreateAsync(IdentityRoleFactory.Create("user"));
                }

                if (!await _userManager.Users.AnyAsync())
                    form.RoleName = "admin";


                CustomIdentityUser user = form;

                var result = await _userManager.CreateAsync(user, form.Password);
                if (result.Succeeded)
                {

                    // lägg till användaren till sin roll
                    await _userManager.AddToRoleAsync(user, form.RoleName);

                    var isSignedIn = await _signInManager.PasswordSignInAsync(user.Email!, form.Password, false, false);
                    if (isSignedIn.Succeeded)
                        return LocalRedirect(form.ReturnUrl);

                    return RedirectToAction("SignIn", "Auth");
                }                   
            }
 
            return View(form);
           
        }

        #endregion

        #region SignIn

        public IActionResult SignIn(string returnUrl = null!)
        {
            _signInViewModel.ReturnUrl = returnUrl ?? Url.Content("/");
            return View(_signInViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel form)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                if (result.Succeeded)
                    return LocalRedirect(form.ReturnUrl);

                ModelState.AddModelError("", "Felaktig e-postadress eller lösenord");
            }

            return View(form);
        }

        #endregion

        #region SignOut

        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");   
        }

        #endregion
    }
}
