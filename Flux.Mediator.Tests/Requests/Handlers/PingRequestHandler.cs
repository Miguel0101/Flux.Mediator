using Flux.Mediator.Abstractions.Requests;

namespace Flux.Mediator.Tests.Requests.Handlers;

public sealed class PingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => Task.FromResult("pong");
}
