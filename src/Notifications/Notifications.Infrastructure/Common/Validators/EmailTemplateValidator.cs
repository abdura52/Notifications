using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(emailTemplate => emailTemplate.Content)
            .NotEmpty()
            .WithMessage("Email template content is required")
            .MinimumLength(10)
            .WithMessage("Email template content must be at least 10 characters long")
            .MaximumLength(256)
            .WithMessage("Email template content must be at most 256 characters long");

        RuleFor(emailTemplate => emailTemplate.NotificationType)
            .Equal(NotificationType.Email)
            .WithMessage("Email template notification type must be Email!");

    }
}
