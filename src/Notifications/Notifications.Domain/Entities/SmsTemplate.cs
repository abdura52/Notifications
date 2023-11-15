namespace Notifications.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        NotificationType = Enums.NotificationType.Sms;
    }
}
