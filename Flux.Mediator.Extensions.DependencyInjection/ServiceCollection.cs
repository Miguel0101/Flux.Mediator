using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Core.Dispatching;
using Flux.Mediator.Core.Handlers;

namespace Flux.Mediator.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluxMediator(this IServiceCollection services)
    {
        services.AddSingleton(HandlerRegistryBuilder.Build(services));
        services.AddSingleton<HandlerResolver>();
        services.AddSingleton<IMediator, MediatorCore>(); ;

        return services;
    }
}
