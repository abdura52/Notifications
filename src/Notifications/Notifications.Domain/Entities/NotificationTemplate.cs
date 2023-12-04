using Notifications.Domain.Common.Models;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public abstract class NotificationTemplate : IEntity
{
    public Guid Id { get; set; }

    public string Content { get; set; } = default!;

    public NotificationType NotificationType { get; set; }

    public NotificationTemplateType NotificationTemplateType { get; set; }

    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
}
