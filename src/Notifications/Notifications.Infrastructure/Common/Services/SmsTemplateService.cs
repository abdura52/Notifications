using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Common.Models.Querying;
using Notifications.Application.Common.Notification.Services;
using Notifications.Application.Common.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Services;

public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _repository;
    private readonly IValidator<SmsTemplate> _validator;

    public SmsTemplateService(ISmsTemplateRepository repository, IValidator<SmsTemplate> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _validator.Validate(smsTemplate);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _repository.CreateAsync(smsTemplate, saveChanges, cancellationToken);

        return smsTemplate;
    }

    public IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>> predicate = default, bool asNoTracking = false)
    {
        return _repository.Get(predicate, asNoTracking);
    }

    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOptions)
            .ToListAsync(cancellationToken);
    }

    public async ValueTask<SmsTemplate?> GetByTypeAsync(NotificationTemplateType templateType, CancellationToken cancellationToken = default)
    {
        return await Get(template => template.NotificationTemplateType == templateType)
            .SingleOrDefaultAsync();
    }
}
