namespace WebApp.Models
{
    public class BestCollection
    {
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public IEnumerable<CollectionItem> Items { get; set; } = new List<CollectionItem>();
    }
}
