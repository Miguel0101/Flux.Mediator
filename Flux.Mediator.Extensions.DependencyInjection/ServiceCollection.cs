using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Core.Dispatching;

namespace Flux.Mediator.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluxMediator(this IServiceCollection services)
    {
        services.AddSingleton<IMediator, MediatorCore>();

        return services;
    }
}
