using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Tests.Shared.Counters;

namespace Flux.Mediator.Tests.Requests.Handlers;

public sealed class CountingRequestHandler(Counter counter) : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
    {
        counter.Increment();
        return Task.FromResult("counted");
    }
}
