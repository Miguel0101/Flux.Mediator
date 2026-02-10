namespace Flux.Mediator.Abstractions.Requests;

public interface IDynamicRequestHandler
{
    Task<TResult> HandleAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default);
}