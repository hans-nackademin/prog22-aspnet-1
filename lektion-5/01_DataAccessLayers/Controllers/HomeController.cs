using _01_DataAccessLayers.Contexts;
using _01_DataAccessLayers.Services;
using _01_DataAccessLayers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _01_DataAccessLayers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            await _productService.CreateAsync();

            var viewModel = new HomeIndexViewModel
            {
                SqlProducts = await _productService.GetAllFromSqlAsync(),
                NoSqlProducts = await _productService.GetAllFromNoSqlAsync()
            };

            return View(viewModel);
        }
    }
}
