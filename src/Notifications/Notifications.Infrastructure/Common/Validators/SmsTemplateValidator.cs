using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validators;

public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .WithMessage("Sms template content is required")
            .MinimumLength(10)
            .MaximumLength(256);

        RuleFor(template => template.NotificationType)
            .Equal(NotificationType.Sms)
            .WithMessage("Sms template notification type must be Sms");
    }
}
