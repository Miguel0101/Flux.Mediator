using System.Runtime.CompilerServices;
using Flux.Mediator.Abstractions.Streaming;
using Flux.Mediator.Tests.Shared.Counters;

namespace Flux.Mediator.Tests.Streaming.Handlers;

public sealed class CountingNumberStreamRequestHandler(Counter counter) : IStreamRequestHandler<NumberStreamRequest, int>
{
    public async IAsyncEnumerable<int> HandleStream(NumberStreamRequest request, [EnumeratorCancellation] CancellationToken ct = default)
    {
        counter.Increment();

        for (var i = 1; i <= request.Count; i++)
        {
            ct.ThrowIfCancellationRequested();
            await Task.Delay(1, ct);
            yield return i;
        }
    }
}
