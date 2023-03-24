using _01_DataAccessLayers.Contexts;
using _01_DataAccessLayers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_DataAccessLayers.Services
{
    public class ProductService
    {
        private readonly SqlContext _sql;
        private readonly NoSqlContext _noSql;

        public ProductService(SqlContext sql, NoSqlContext noSql)
        {
            _sql = sql;
            _noSql = noSql;
        }

        public async Task CreateAsync()
        {
            var productEntity = new ProductEntity
            {
                ArticleNumber = Guid.NewGuid().ToString(),
                Name = "Product",
                Price = 100
            };

            _sql.Add(productEntity);
            await _sql.SaveChangesAsync();

            _noSql.Add(productEntity);
            await _noSql.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllFromSqlAsync()
        {
            return await _sql.Products.ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllFromNoSqlAsync()
        {
            return await _noSql.Products.ToListAsync();
        }
    }
}