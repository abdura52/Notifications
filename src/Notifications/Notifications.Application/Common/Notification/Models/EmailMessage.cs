using Notifications.Domain.Entities;

namespace Notifications.Application.Common.Notification.Models;

public class EmailMessage : NotificationMessage
{
    public string SenderEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public NotificationTemplate Template { get; set; }= default!;

    public string Subject { get; set; } = default!;

    public string Body { get; set; } = default!;
}
