namespace Notifications.Application.Common.Notification.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest()
    {
        Type = Domain.Enums.NotificationType.Email;
    }
}
