using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Dispatching;

internal class MediatorCore(IServiceProvider provider) : IMediator
{
    public async Task<TResult> SendAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResult));

        var handlers = provider
            .GetServices(handlerType)
            .OfType<IDynamicRequestHandler>()
            .ToArray();

        return handlers.Length switch
        {
            0 => throw new InvalidOperationException($"No handler registered found for {handlerType.Name}."),
            1 => await handlers[0].HandleAsync(request, ct),
            _ => throw new InvalidOperationException($"Multiple handlers found for {handlerType.Name}.")
        };
    }
}