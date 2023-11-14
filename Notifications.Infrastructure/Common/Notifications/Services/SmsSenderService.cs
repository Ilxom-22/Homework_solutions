using Notifications.Application.Common.Notifications.Brokers;
using Notifications.Application.Common.Notifications.Services;

namespace Notifications.Infrastructure.Common.Notifications.Services;

public class SmsSenderService : ISmsSenderService
{
    private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;

    public SmsSenderService(IEnumerable<ISmsSenderBroker> smsSenderBrokers)
    {
        _smsSenderBrokers = smsSenderBrokers;
    }

    public async ValueTask<bool> SendAsync(
        string senderPhoneNumber, 
        string receiverPhoneNumber, 
        string message, 
        CancellationToken cancellationToken
    )
    {
        foreach (var smsSenderBroker in _smsSenderBrokers)
        {
            try
            {
                var result = await smsSenderBroker
                    .SendAsync(receiverPhoneNumber, senderPhoneNumber, message, cancellationToken);

                if (result) return result;
            }
            catch
            {
                //TODO : log exception.
            }
        }

        return true;
    }
}