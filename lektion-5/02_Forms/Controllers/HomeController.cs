using _02_Forms.Models.Forms;
using _02_Forms.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _02_Forms.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerService _customerService;

        public HomeController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var form = new CustomerRegistrationForm();
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerRegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerService.CreateAsync(form);

                switch(result)
                {
                    case OkResult:
                        return LocalRedirect("/Account");

                    case ConflictResult:
                        ModelState.AddModelError("", "Det finns redan en användare med samma e-postadress");
                        break;

                    default:
                        ModelState.AddModelError("", "Något gick fel. Kontakta administratören.");
                        break;

                }

            }
       
            return View(form);
        }

    }
}
