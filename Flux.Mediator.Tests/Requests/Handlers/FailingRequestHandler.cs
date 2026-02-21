using Flux.Mediator.Abstractions.Requests;

namespace Flux.Mediator.Tests.Requests.Handlers;

public sealed class FailingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => throw new InvalidOperationException("Handler failed");
}
