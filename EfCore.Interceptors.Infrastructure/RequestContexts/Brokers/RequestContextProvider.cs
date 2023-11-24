using EfCore.Interceptors.Application.Common.RequestContexts.Brokers;
using EfCore.Interceptors.Application.Common.RequestContexts.Models;
using EfCore.Interceptors.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace EfCore.Interceptors.Infrastructure.RequestContexts.Brokers;

public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public RequestContext GetRequestContext()
    {
        var httpContext = httpContextAccessor.HttpContext;
        var userIdClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimConstants.UserId))?.Value;

        var requestContext = new RequestContext
        {
            UserId = userIdClaim is not null ? Guid.Parse(userIdClaim) : Guid.Empty,
            IpAddress = httpContext.Connection.RemoteIpAddress.ToString(),
            UserAgent = httpContext.Request.Headers[HeaderNames.UserAgent].ToString()
        };

        return requestContext;
    }
}