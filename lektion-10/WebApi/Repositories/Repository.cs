using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Repositories;

public abstract class Repository<TEntity> where TEntity : class
{
    private readonly IdentityContext _identity;

    public Repository(IdentityContext identity)
    {
        _identity = identity;
    }


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _identity.Set<TEntity>().Add(entity);
        await _identity.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _identity.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _identity.Set<TEntity>().FirstOrDefaultAsync(predicate);
        if (entity != null)
            return entity;

        return null!;
    }
}
