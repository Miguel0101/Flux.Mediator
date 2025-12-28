namespace Flux.Mediator.Abstractions;

public interface IGenericRequestHandler<TRequest, TResult> : IDynamicRequestHandler
where TRequest : IRequest<TResult>
{
    Task<TResult> HandleAsync(TRequest request, CancellationToken ct = default);
}