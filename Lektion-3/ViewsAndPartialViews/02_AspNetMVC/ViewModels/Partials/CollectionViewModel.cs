using _02_AspNetMVC.Models;

namespace _02_AspNetMVC.ViewModels.Partials
{
    public class CollectionViewModel
    {
        public string Title { get; set; } = null!;
        public List<string> Categories { get; set; } = null!;
        public List<CollectionItemModel> CollectionItems { get; set; } = null!;

    }
}
