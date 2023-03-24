using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_DataAccessLayers.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
