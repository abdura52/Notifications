using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Common.Models.Querying;
using Notifications.Application.Common.Notification.Services;
using Notifications.Application.Common.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Services;

public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator;

    public EmailHistoryService(
        IEmailHistoryRepository emailHistoryRepository,
        IValidator<EmailHistory> validator)
    {
        _emailHistoryRepository = emailHistoryRepository;
        _emailHistoryValidator = validator;
    }

    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailHistoryValidator.Validate(emailHistory);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);

        return emailHistory;
    }

    public IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>> predicate = default, bool asNoTracking = false)
    {
        return _emailHistoryRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOprions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOprions)
            .ToListAsync();
    }
}