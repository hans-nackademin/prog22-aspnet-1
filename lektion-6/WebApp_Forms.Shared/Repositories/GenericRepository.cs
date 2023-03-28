using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp_Forms.Shared.Contexts;

namespace WebApp_Forms.Shared.Repositories;

public abstract class GenericRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected GenericRepository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(TEntity entity)
    {
        return await _context.Set<TEntity>().ToListAsync();
    }


    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return result!;
    }
}
