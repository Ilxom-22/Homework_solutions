﻿using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface ISmsTemplateRepository
{
    IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>>? predicate = default, 
        bool asNoTracking = false
    );

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}