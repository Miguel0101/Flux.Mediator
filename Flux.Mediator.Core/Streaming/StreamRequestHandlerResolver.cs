using Flux.Mediator.Abstractions.Streaming;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Streaming;

internal sealed class StreamRequestHandlerResolver(IServiceProvider provider, StreamRequestHandlerRegistry registry)
{
    public IDynamicStreamRequestHandler GetHandler(Type requestType)
    {
        if (!registry.Entries.TryGetValue(requestType, out var handlerType))
            throw new InvalidOperationException(
                $"No handler registered for request type '{requestType.Name}'.");

        return (IDynamicStreamRequestHandler)provider.GetRequiredService(handlerType);
    }
}
