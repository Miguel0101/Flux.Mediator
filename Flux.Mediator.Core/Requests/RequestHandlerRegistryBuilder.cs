using Flux.Mediator.Abstractions.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Requests;

internal static class RequestHandlerRegistryBuilder
{
    public static RequestHandlerRegistry Build(IServiceCollection services)
    {
        var registry = new RequestHandlerRegistry();

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
