using Flux.Mediator.Abstractions.Streaming;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Streaming;

internal static class StreamRequestHandlerRegistryBuilder
{
    public static StreamRequestHandlerRegistry Build(IServiceCollection services)
    {
        var registry = new StreamRequestHandlerRegistry();

        var handlers = services
            .Where(descriptor => descriptor.ServiceType.IsGenericType &&
                        descriptor.ServiceType.GetGenericTypeDefinition() == typeof(IStreamRequestHandler<,>));

        foreach (var descriptor in handlers)
        {
            var requestType = descriptor.ServiceType.GetGenericArguments()[0];
            registry.Register(requestType, descriptor.ServiceType);
        }

        return registry;
    }
}
