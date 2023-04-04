using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class ProductHttpRequest
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Tag { get; set; } = null!;

        public static implicit operator ProductEntity(ProductHttpRequest req) 
        {
            return new ProductEntity
            {
                ArticleNumber = req.ArticleNumber,
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                Tag = req.Tag

            };
        }
    }
}
