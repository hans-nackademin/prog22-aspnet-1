using _02_AspNetMVC.Models;
using _02_AspNetMVC.ViewModels.Partials;

namespace _02_AspNetMVC.ViewModels.Home;

public class IndexViewModel
{
    public CollectionModel BestCollection { get; set; } = null!;
    public ShowcaseModel Showcase { get; set; } = null!;
}
