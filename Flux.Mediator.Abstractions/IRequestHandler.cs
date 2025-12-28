namespace Flux.Mediator.Abstractions;

public abstract class IRequestHandler<TRequest, TResult> : IGenericRequestHandler<TRequest, TResult>
where TRequest : IRequest<TResult>
{
    public abstract Task<TResult> HandleAsync(TRequest request, CancellationToken ct = default);

    async Task<T> IDynamicRequestHandler.HandleAsync<T>(IRequest<T> request, CancellationToken ct)
    {
        var result = await HandleAsync((TRequest)request, ct) ??
            throw new InvalidOperationException("The handler cannot return null.");

        return (T)(object)result;
    }
}