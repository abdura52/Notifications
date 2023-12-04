using FluentValidation;
using Notifications.Application.Common.Notification.Services;
using Notifications.Domain.Entities;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Services;

public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository, IValidator<SmsHistory> validator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = validator;
    }

    public async ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsHistoryValidator.Validate(smsHistory);

        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);

        return smsHistory;
    }

    public IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>> predicate, bool asNoTracking = false)
    {
        return _smsHistoryRepository.Get(predicate, asNoTracking);
    }
}
