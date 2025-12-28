using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions;

namespace Flux.Mediator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluxMediator(this IServiceCollection services)
    {
        services.AddSingleton<IMediator, Core.Mediator>();

        return services;
    }
}
