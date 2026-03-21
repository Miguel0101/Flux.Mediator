namespace Flux.Mediator.Abstractions.Streaming;

public interface IStreamRequestHandler<TStreamRequest, TResponse> : IDynamicStreamRequestHandler
    where TStreamRequest : IStreamRequest<TResponse>
{
    IAsyncEnumerable<TResponse> HandleStream(TStreamRequest request, CancellationToken ct = default);

    IAsyncEnumerable<T> IDynamicStreamRequestHandler.HandleAsync<T>(IStreamRequest<T> request, CancellationToken ct)
    {
        var result = HandleStream((TStreamRequest)request, ct) ??
            throw new InvalidOperationException("The handler cannot return null.");

        return (IAsyncEnumerable<T>)result;
    }
}