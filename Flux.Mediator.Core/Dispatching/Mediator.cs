using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Core.Handlers;

namespace Flux.Mediator.Core.Dispatching;

internal class MediatorCore(HandlerResolver resolver) : IMediator
{
    public Task<TResult> SendAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default)
    {
        var requestType = request.GetType();
        var handler = resolver.GetHandler(requestType);

        return handler.HandleAsync(request, ct);
    }
}