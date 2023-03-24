using _01_DataAccessLayers.Models.Entities;

namespace _01_DataAccessLayers.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductEntity> SqlProducts { get; set; } = null!;
        public IEnumerable<ProductEntity> NoSqlProducts { get; set; } = null!;
    }
}
