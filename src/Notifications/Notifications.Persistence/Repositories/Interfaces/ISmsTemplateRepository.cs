using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface ISmsTemplateRepository
{
    IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<SmsTemplate> GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> UpdateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> DeleteAsync(
       SmsTemplate smsTemplate,
       bool saveChanges = true,
       CancellationToken cancellationToken = default);


    ValueTask<SmsTemplate> DeleteByIdAsync(
       Guid id,
       bool saveChanges = true,
       CancellationToken cancellationToken = default);
}
