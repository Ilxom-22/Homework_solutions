namespace EfCore.Interceptors.Domain.Brokers;

public interface IRequestUserContextProvider
{
    Guid GetUserId(CancellationToken cancellationToken = default);
}