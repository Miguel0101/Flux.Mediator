using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Core.Dispatching;
using Flux.Mediator.Core.Requests;
using Flux.Mediator.Core.Notifications;

namespace Flux.Mediator.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluxMediator(this IServiceCollection services)
    {
        services.AddSingleton(RequestHandlerRegistryBuilder.Build(services));
        services.AddSingleton<RequestHandlerResolver>();

        services.AddSingleton(NotificationHandlerRegistryBuilder.Build(services));
        services.AddSingleton<NotificationHandlerResolver>();

        services.AddSingleton<IMediator, MediatorCore>();

        return services;
    }
}
