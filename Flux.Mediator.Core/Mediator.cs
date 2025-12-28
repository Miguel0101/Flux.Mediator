using Flux.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core;

internal class Mediator : IMediator
{
    private readonly IServiceProvider _provider;

    public Mediator(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResult> SendAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResult));

        using var scope = _provider.CreateScope();

        var handlers = scope.ServiceProvider
            .GetServices(handlerType)
            .OfType<IDynamicRequestHandler>();

        try
        {
            var handler = handlers.Single();

            return await handler.HandleAsync(request, ct);
        }
        catch
        {
            throw new InvalidOperationException("A request must contain exactly one handler.");
        }
    }
}