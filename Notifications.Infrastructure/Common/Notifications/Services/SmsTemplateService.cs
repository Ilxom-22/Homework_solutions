using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Common.Notifications.Services;
using Notifications.Application.Common.Querying.Extensions;
using Notifications.Application.Common.Querying.Models;
using Notifications.Domain.Entities;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Infrastructure.Common.Notifications.Services;

public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _smsTemplateRepository;
    private readonly IValidator<SmsTemplate> _smsTemplateValidator;

    public SmsTemplateService(ISmsTemplateRepository smsTemplateRepository, IValidator<SmsTemplate> smsTemplateValidator)
    {
        _smsTemplateRepository = smsTemplateRepository;
        _smsTemplateValidator = smsTemplateValidator;
    }

    public async ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsTemplateValidator.Validate(smsTemplate);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await _smsTemplateRepository.CreateAsync(smsTemplate, saveChanges, cancellationToken);   
    }

    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _smsTemplateRepository
            .Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOptions)
            .ToListAsync(cancellationToken);
}