using EfCore.Interceptors.Application.Common.RequestContexts.Models;

namespace EfCore.Interceptors.Application.Common.RequestContexts.Brokers;

public interface IRequestContextProvider
{
    RequestContext GetRequestContext();
}