using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface ISmsHistoryRepository
{
    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<SmsHistory> DeleteAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<SmsHistory> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    IQueryable<SmsHistory> Get(
        Expression<Func<SmsHistory, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<SmsHistory?>? GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsHistory> UpdateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
