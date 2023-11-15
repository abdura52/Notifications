using Notifications.Domain.Common.Models;

namespace Notifications.Domain.Entities;

public class EmailHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public string Content { get; set; } = default!;

    public string Subject { get; set; } = default!;

    public DateTime SendedTime { get; set; }
}
