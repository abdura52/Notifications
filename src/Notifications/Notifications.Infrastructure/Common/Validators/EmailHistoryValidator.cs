using FluentValidation;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Validators;

public class EmailHistoryValidator : AbstractValidator<EmailHistory>
{
    public EmailHistoryValidator()
    {
        RuleFor(history => history.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);


        RuleFor(history => history.Subject)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);
    }
}
