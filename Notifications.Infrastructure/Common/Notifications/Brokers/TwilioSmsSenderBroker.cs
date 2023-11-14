using Notifications.Application.Common.Notifications.Brokers;

namespace Notifications.Infrastructure.Common.Notifications.Brokers;

public class TwilioSmsSenderBroker : ISmsSenderBroker
{
    public ValueTask<bool> SendAsync(
        string receiverPhoneNumber, 
        string senderPhoneNumber, 
        string message, 
        CancellationToken cancellationToken = default
    )
    {
      /*  var userName = "ACe09f7247dfbdf25dbe2ef0acdf2279f9";
        var password = "e1fdedded3a1a2ddf74da5336dd7687d";

        TwilioClient.Init(userName, password);

        var messageContent = MessageResource.Create(
            body: message,
            from: new Twilio.Types.PhoneNumber(senderPhoneNumber),
            to: new Twilio.Types.PhoneNumber(receiverPhoneNumber)
        );*/

        return new(true);
    }
}