using Notifications.Domain.Entities;
using Notifications.Persistence.DbContexts;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories;

public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public new ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(smsHistory, saveChanges, cancellationToken);
    }

    public new ValueTask<SmsHistory> DeleteAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(smsHistory, saveChanges, cancellationToken);
    }

    public new ValueTask<SmsHistory> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public new IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<SmsHistory?>? GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public new ValueTask<SmsHistory> UpdateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(smsHistory, saveChanges, cancellationToken);
    }
}
