namespace WebApp.Models
{
    public class ProductModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Tag { get; set; } = null!;
    }
}
