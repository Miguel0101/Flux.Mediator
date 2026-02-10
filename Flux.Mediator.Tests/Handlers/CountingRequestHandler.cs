using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Tests.Requests;

namespace Flux.Mediator.Tests.Handlers;

public sealed class CountingRequestHandler : IRequestHandler<PingRequest, string>
{
    public static int Count;

    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
    {
        Interlocked.Increment(ref Count);
        return Task.FromResult("counted");
    }
}
