using _02_AspNetMVC.Models;
using _02_AspNetMVC.ViewModels.Home;
using _02_AspNetMVC.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;

namespace _02_AspNetMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Showcase = new ShowcaseModel
                {
                    Title = "Exclusive Chair gold Collection.",
                    Ingress = "WELCOME TO BMERKETO SHOP",
                    ButtonText = "SHOP NOW",
                    ImageUrl = "images/placeholders/625x647.svg"
                },
                BestCollection = new CollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string>
                    {
                        "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty"
                    },
                    CollectionItems = new List<CollectionItemModel>
                    {
                        new CollectionItemModel { Id = "1", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "2", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "3", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "4", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "5", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "6", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "7", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                        new CollectionItemModel { Id = "8", Title = "Apple watch collection", Price = 30.00m, ImageUrl = "images/placeholders/270x295.svg" },
                    }
                }
            };

            return View(viewModel);
        }
    }
}
