using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Common.Models;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories;

public class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    private readonly DbContext _dbContext;
    protected TContext DbContext => (TContext)_dbContext;

    public EntityRepositoryBase(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected async ValueTask<TEntity?> GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken);
    }

    protected async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        await DbContext.AddAsync(entity, cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        DbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var entity = await GetByIdAsync(id, true, cancellationToken);

        return await DeleteAsync(entity, saveChanges, cancellationToken);
    }
}
