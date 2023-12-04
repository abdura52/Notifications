using Notifications.Application.Common.Models.Querying;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using System.Linq.Expressions;

namespace Notifications.Application.Common.Notification.Services;

public interface IEmailTemplateService
{
    IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> GetByTypeAsync(
        NotificationTemplateType templateType,
        CancellationToken token = default);

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
