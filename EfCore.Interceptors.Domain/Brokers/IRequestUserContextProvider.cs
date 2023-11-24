namespace EfCore.Interceptors.Domain.Brokers;

public interface IRequestUserContextProvider
{
    Guid GetUserIdAsync(CancellationToken cancellationToken = default);
}