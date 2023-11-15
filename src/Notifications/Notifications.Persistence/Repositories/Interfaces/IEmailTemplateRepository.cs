using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<EmailTemplate?>? GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);


    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> UpdateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> DeleteAsync(
       EmailTemplate emailTemplate,
       bool saveChanges = true,
       CancellationToken cancellationToken = default);


    ValueTask<EmailTemplate> DeleteByIdAsync(
       Guid id,
       bool saveChanges = true,
       CancellationToken cancellationToken = default);
}
