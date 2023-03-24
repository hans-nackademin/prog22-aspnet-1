using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    internal class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
