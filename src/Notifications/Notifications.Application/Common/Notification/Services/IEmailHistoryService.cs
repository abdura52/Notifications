using Notifications.Application.Common.Models.Querying;
using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Application.Common.Notification.Services;

public interface IEmailHistoryService
{
    IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOprions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
