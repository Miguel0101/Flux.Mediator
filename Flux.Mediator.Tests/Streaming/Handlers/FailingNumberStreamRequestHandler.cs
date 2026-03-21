using Flux.Mediator.Abstractions.Streaming;

namespace Flux.Mediator.Tests.Streaming.Handlers;

public sealed class FailingNumberStreamRequestHandler : IStreamRequestHandler<NumberStreamRequest, int>
{
    public IAsyncEnumerable<int> HandleStream(NumberStreamRequest request, CancellationToken ct = default)
    {
        throw new InvalidOperationException("Stream failure");
    }
}
