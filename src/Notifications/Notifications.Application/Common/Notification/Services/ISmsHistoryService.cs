using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Application.Common.Notification.Services;

public interface ISmsHistoryService
{
    IQueryable<SmsHistory> Get(
        Expression<Func<SmsHistory, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

}
