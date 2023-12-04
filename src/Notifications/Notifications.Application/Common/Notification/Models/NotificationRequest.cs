using Notifications.Domain.Enums;

namespace Notifications.Application.Common.Notification.Models;

public class NotificationRequest
{
    public Guid? SenderId { get; set; } = null;

    public Guid ReceiverId { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public NotificationType Type { get; set; }

    public Dictionary<string, string> Variables { get; set; }
}