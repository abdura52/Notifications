using FluentValidation;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Validators;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator()
    {
        RuleFor(history => history.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);
    }
}
