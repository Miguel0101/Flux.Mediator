using Flux.Mediator.Abstractions.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Handlers;

internal static class HandlerRegistryBuilder
{
    public static HandlerRegistry Build(IServiceCollection services)
    {
        var registry = new HandlerRegistry();

        var handlers = services
            .Where(descriptor => descriptor.ServiceType.IsGenericType &&
                        descriptor.ServiceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

        foreach (var descriptor in handlers)
        {
            var requestType = descriptor.ServiceType.GetGenericArguments()[0];
            registry.Register(requestType, descriptor.ServiceType);
        }

        return registry;
    }
}
