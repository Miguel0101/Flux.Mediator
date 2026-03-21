using System.Runtime.CompilerServices;
using Flux.Mediator.Abstractions.Streaming;

namespace Flux.Mediator.Benchmarks.Streaming;

public sealed class NumberStreamRequestHandler : IStreamRequestHandler<NumberStreamRequest, int>
{
    public async IAsyncEnumerable<int> HandleStream(NumberStreamRequest request, [EnumeratorCancellation] CancellationToken ct = default)
    {
        for (var i = 1; i <= request.Count; i++)
        {
            ct.ThrowIfCancellationRequested();
            yield return i;
        }
    }
}
