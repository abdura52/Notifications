namespace Notifications.Application.Common.Notification.Models;

public class SmsNotificationRequest : NotificationRequest
{
    public SmsNotificationRequest()
    {
        Type = Domain.Enums.NotificationType.Sms;
    }
}
