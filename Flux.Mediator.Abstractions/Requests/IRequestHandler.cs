namespace Flux.Mediator.Abstractions.Requests;

public interface IRequestHandler<TRequest, TResult> : IDynamicRequestHandler
where TRequest : IRequest<TResult>
{
    Task<TResult> HandleAsync(TRequest request, CancellationToken ct = default);

    async Task<T> IDynamicRequestHandler.HandleAsync<T>(IRequest<T> request, CancellationToken ct)
    {
        var result = await HandleAsync((TRequest)request, ct) ??
            throw new InvalidOperationException("The handler cannot return null.");

        return (T)(object)result;
    }
}