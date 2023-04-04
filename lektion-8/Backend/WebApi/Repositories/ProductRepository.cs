using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class ProductRepository
    {
        #region constructors - dependency injections

        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<ProductHttpResponse> GetAsync(string articleNumber)
        {
            var item = await _context.Products.FindAsync(articleNumber);
            return item!;
        }

        public async Task<IEnumerable<ProductHttpResponse>> GetAllAsync()
        {
            var items = await _context.Products.ToListAsync();
            var products = new List<ProductHttpResponse>();
            
            foreach (var item in items)
                products.Add(item);
            
            return products;
        }

        public async Task<IEnumerable<ProductHttpResponse>> GetAllByTagAsync(string tag)
        {
            var items = await _context.Products.Where(x => x.Tag == tag).ToListAsync();
            var products = new List<ProductHttpResponse>();

            foreach (var item in items)
                products.Add(item);

            return products;
        }

        public async Task<ProductHttpResponse> CreateAsync(ProductEntity entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
