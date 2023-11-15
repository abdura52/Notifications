using Notifications.Domain.Common.Models;

namespace Notifications.Domain.Entities;

public class SmsHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public string Content { get; set; } = default!;

    public DateTime SendedTime { get; set; }
}
