using System.Collections.Concurrent;
using Flux.Mediator.Abstractions.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Handlers;

internal sealed class HandlerResolver(IServiceProvider provider, HandlerRegistry registry)
{
    private readonly ConcurrentDictionary<Type, IDynamicRequestHandler> _cache = new();

    public IDynamicRequestHandler GetHandler(Type requestType)
    {
        return _cache.GetOrAdd(requestType, type =>
        {
            if (!registry.Entries.TryGetValue(type, out var handlerInterfaceType))
                throw new InvalidOperationException(
                    $"No handler registered for request type '{type.Name}'.");

            return (IDynamicRequestHandler)provider.GetRequiredService(handlerInterfaceType);
        });
    }
}
