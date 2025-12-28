namespace Flux.Mediator.Abstractions;

public interface IDynamicRequestHandler
{
    Task<TResult> HandleAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default);
}