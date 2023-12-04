using Notifications.Application.Common.Models.Querying;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using System.Linq.Expressions;

namespace Notifications.Application.Common.Notification.Services;

public interface ISmsTemplateService
{
    IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>> predicate,
        bool asNoTracking = false);

    ValueTask<IList<SmsTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> GetByTypeAsync(
        NotificationTemplateType templateType,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}