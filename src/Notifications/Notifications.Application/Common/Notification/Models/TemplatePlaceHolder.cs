namespace Notifications.Application.Common.Notification.Models;

public class TemplatePlaceHolder
{
    public string Placeholder { get; set; } = default!;

    public string PlaceholderValue { get; set; } = default!;

    public string? Value { get; set; }

    public bool IsValid { get; set; }
}
