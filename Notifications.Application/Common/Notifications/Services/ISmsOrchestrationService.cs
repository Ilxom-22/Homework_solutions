using Notifications.Domain.Common.Exceptions;
using Notifications.Domain.Enums;

namespace Notifications.Application.Common.Notifications.Services;

public interface ISmsOrchestrationService
{
   ValueTask<FuncResult<bool>> SendAsync(
       string senderPhoneNumber,
       string receiverPhoneNumber,
       NotificationTemplateType templateType,
       Dictionary<string, string> variables,
       CancellationToken cancellationToken = default
   );
}