using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Forms;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly NewsletterService _newsletterService;

        public ContactsController(NewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterNewsLetter(NewsletterForm form)
        {
            if (ModelState.IsValid)
            {
                await _newsletterService.SubscribeAsync(form.Email);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
