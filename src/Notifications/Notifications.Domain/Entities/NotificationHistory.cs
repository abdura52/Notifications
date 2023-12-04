using Notifications.Domain.Common.Models;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public abstract class NotificationHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public Guid TemplateId { get; set; }

    public virtual NotificationTemplate Template { get; set; }

    public NotificationType NotificationType { get; set; }

    public string Content { get; set; } = default!;
}
