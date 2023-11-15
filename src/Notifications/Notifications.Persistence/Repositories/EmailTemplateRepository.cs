using Notifications.Domain.Entities;
using Notifications.Persistence.DbContexts;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public new ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public new ValueTask<EmailTemplate> DeleteAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public new ValueTask<EmailTemplate> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public new IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<EmailTemplate?>? GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public new ValueTask<EmailTemplate> UpdateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}
