using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Tests.Counters;
using Flux.Mediator.Tests.Requests;

namespace Flux.Mediator.Tests.Handlers;

public sealed class CountingRequestHandler(Counter counter) : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
    {
        counter.Increment();
        return Task.FromResult("counted");
    }
}
