using Notifications.Domain.Entities;

namespace Notifications.Application.Common.Notification.Models;

public class SmsMessage : NotificationMessage
{
    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!;

    public NotificationTemplate Template { get; set; } = default!;
}
