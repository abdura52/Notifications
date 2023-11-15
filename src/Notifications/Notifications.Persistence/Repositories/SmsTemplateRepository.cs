using Notifications.Domain.Entities;
using Notifications.Persistence.DbContexts;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
    }

    public ValueTask<SmsTemplate> DeleteAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(smsTemplate, saveChanges, cancellationToken);
    }

    public ValueTask<SmsTemplate> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<SmsTemplate> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<SmsTemplate> UpdateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(smsTemplate, saveChanges, cancellationToken);
    }
}
