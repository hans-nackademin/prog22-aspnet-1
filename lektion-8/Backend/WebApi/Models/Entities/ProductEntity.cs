using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Tag { get; set; } = null!;

        public static implicit operator ProductHttpResponse(ProductEntity entity)
        {
            return new ProductHttpResponse
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Tag = entity.Tag
            };
        }
    }
}
