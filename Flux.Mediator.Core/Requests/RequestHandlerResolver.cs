using Flux.Mediator.Abstractions.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Requests;

internal sealed class RequestHandlerResolver(IServiceProvider provider, RequestHandlerRegistry registry)
{
    public IDynamicRequestHandler GetHandler(Type requestType)
    {
        if (!registry.Entries.TryGetValue(requestType, out var handlerType))
            throw new InvalidOperationException(
                $"No handler registered for request type '{requestType.Name}'.");

        return (IDynamicRequestHandler)provider.GetRequiredService(handlerType);
    }
}
