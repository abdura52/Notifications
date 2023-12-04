namespace Notifications.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        NotificationType = Enums.NotificationType.Email;
    }

    public string SenderEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public string Subject { get; set; } = default!;
}
