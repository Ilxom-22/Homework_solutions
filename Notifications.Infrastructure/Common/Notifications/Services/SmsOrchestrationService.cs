using Notifications.Application.Common.Notifications.Services;
using Notifications.Domain.Common.Exceptions;
using Notifications.Domain.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace Notifications.Infrastructure.Common.Notifications.Services;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    public ValueTask<FuncResult<bool>> SendAsync(string senderPhoneNumber, string receiverPhoneNumber, NotificationTemplateType templateType, Dictionary<string, string> variables, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public string GetTemplate(NotificationTemplateType templateType) =>
        templateType switch
        {
            NotificationTemplateType.SystemWelcomeNotification => "Welcome to the system {{User}}!",
            NotificationTemplateType.IdentityVerificationNotification => "Verify your phone number by entering this 6 digit in our website, {{VerificationCode}}",
            _ => throw new ArgumentException("Invalid Notification Template Type")
        };

    public string GetMessage(string template, Dictionary<string, string> variables)
    {
        var messageBuilder = new StringBuilder();

        var pattern = @"\{\{([^\{\}]+)\}\}";
        var matchValuePattern = "{{(.*?)}}";

        var matches = Regex.Matches(template, pattern)
            .Select(match =>
            {
                var placeholder = match.Value;
                var placeholderValue = Regex.Match(placeholder, matchValuePattern).Groups[1].Value;
                var valid = variables.TryGetValue(placeholderValue, out var value);

                return new
                {
                    PlaceHolder = placeholder,
                    Value = value,
                    IsValid = valid
                };
            });

        foreach (var match in matches)
            if (match.IsValid)
                messageBuilder.Replace(match.PlaceHolder, match.Value);

        return messageBuilder.ToString();
    }
}