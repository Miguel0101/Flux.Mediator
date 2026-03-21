using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Core.Dispatching;
using Flux.Mediator.Core.Requests;
using Flux.Mediator.Core.Notifications;
using Flux.Mediator.Core.Streaming;

namespace Flux.Mediator.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluxMediator(this IServiceCollection services)
    {
        services.AddSingleton(RequestHandlerRegistryBuilder.Build(services));
        services.AddSingleton(NotificationHandlerRegistryBuilder.Build(services));
        services.AddSingleton(StreamRequestHandlerRegistryBuilder.Build(services));

        services.AddScoped<RequestHandlerResolver>();
        services.AddScoped<NotificationHandlerResolver>();
        services.AddScoped<StreamRequestHandlerResolver>();

        services.AddScoped<IMediator, MediatorCore>();

        return services;
    }
}
