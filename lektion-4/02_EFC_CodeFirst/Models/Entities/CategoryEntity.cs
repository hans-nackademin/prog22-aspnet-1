namespace _02_EFC_CodeFirst.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
