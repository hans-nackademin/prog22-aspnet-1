using DataAccess.Contexts;

namespace DataAccess.Repositories;

public class ProductRepository
{
    private readonly DataContext _context;

    public ProductRepository()
    {
        _context = new DataContext();
    }
}
