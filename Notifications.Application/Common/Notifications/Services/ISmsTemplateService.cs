using Notifications.Application.Common.Querying.Models;
using Notifications.Domain.Entities;

namespace Notifications.Application.Common.Notifications.Services;

public interface ISmsTemplateService
{
    ValueTask<IList<SmsTemplate>> GetByFilterAsync(
      FilterPagination paginationOptions,
      bool asNoTracking = false,
      CancellationToken cancellationToken = default
  );

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}