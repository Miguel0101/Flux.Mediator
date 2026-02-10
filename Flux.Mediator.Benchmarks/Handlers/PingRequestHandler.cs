using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Benchmarks.Requests;

namespace Flux.Mediator.Benchmarks.Handlers;

public sealed class PingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => Task.FromResult("pong");
}
