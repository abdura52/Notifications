namespace Notifications.Domain.Entities;
using Type = Notifications.Domain.Enums.NotificationType;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        NotificationType = Type.Email;
    }

    public string Subject { get; set; } = default!;

}
