using Notifications.Domain.Entities;
using Notifications.Persistence.DbContexts;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories;

public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public new ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }

    public new ValueTask<EmailHistory> DeleteAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(emailHistory, saveChanges, cancellationToken);
    }

    public new ValueTask<EmailHistory> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public new IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<EmailHistory?>? GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public new ValueTask<EmailHistory> UpdateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(emailHistory, saveChanges, cancellationToken);
    }
}
