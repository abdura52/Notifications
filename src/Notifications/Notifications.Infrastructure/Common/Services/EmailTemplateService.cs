using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Common.Models.Querying;
using Notifications.Application.Common.Notification.Services;
using Notifications.Application.Common.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IValidator<EmailTemplate> _validator;

    public EmailTemplateService(
        IEmailTemplateRepository emailTemplateRepository,
        IValidator<EmailTemplate> validator)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _validator = validator;
    }

    public async ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _validator.Validate(emailTemplate);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);

        return emailTemplate;
    }

    public IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>> predicate = default, bool asNoTracking = false)
        => _emailTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking: asNoTracking)
                .ApplyPagination(paginationOptions)
                .ToListAsync();
    }
}
