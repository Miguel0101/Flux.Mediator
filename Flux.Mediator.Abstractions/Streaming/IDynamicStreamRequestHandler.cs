namespace Flux.Mediator.Abstractions.Streaming;

public interface IDynamicStreamRequestHandler
{
    IAsyncEnumerable<TResult> HandleAsync<TResult>(IStreamRequest<TResult> request, CancellationToken ct = default);
}