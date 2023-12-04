namespace Notifications.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        NotificationType = Enums.NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; }

    public string ReceiverPhoneNumber { get; set; }
}
