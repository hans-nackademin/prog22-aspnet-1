using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Forms;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new BestCollection
            {
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                Items = new List<CollectionItem>
                {
                    new CollectionItem() { Id = 1, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 2, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 3, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 4, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 5, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 6, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 7, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                    new CollectionItem() { Id = 8, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                }
            },

            UpToSell = new CollectionItem[]
            {
                new CollectionItem() { Id = 9, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/369x310.svg" },
                new CollectionItem() { Id = 10, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/369x310.svg" }
            },

            TopSelling = new List<CollectionItem>
            {
                new CollectionItem() { Id = 11, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 12, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 13, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 14, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 15, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 16, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" },
                new CollectionItem() { Id = 17, Title = "Apple watch collection", Price = 30.00M, ImageUrl = "images/placeholders/270x295.svg" }
            },

            NewsletterForm = new NewsletterForm()
        };

        return View(viewModel);
    }
}
