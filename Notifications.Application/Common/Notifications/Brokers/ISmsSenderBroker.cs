namespace Notifications.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(
        string receiverPhoneNumber,
        string senderPhoneNumber,
        string message,
        CancellationToken cancellationToken = default
    ); 
}