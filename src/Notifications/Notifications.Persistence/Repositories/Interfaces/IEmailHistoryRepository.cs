using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface IEmailHistoryRepository
{
    ValueTask<EmailHistory> CreateAsync(
         EmailHistory emailHistory,
         bool saveChanges = true,
         CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> DeleteAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<EmailHistory?>? GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> UpdateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
