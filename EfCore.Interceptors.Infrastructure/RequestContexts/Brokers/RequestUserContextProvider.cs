using EfCore.Interceptors.Domain.Brokers;
using EfCore.Interceptors.Domain.Constants;
using EfCore.Interceptors.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EfCore.Interceptors.Infrastructure.RequestContexts.Brokers;

public class RequestUserContextProvider(
    IHttpContextAccessor httpContextAccessor,
    IOptions<RequestUserContextSettings> requestUserContextSettings
) : IRequestUserContextProvider
{
    private readonly RequestUserContextSettings _requestUserContextSettings = requestUserContextSettings.Value;

    public Guid GetUserIdAsync(CancellationToken cancellationToken = default)
    {
        var httpContext = httpContextAccessor.HttpContext;
        
        var userIdClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;

        return userIdClaim is not null ? Guid.Parse(userIdClaim) : _requestUserContextSettings.SystemUserId;
    }
}