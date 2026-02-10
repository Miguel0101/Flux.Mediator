using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Tests.Requests;

namespace Flux.Mediator.Tests.Handlers;

public sealed class FailingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => throw new InvalidOperationException("Handler failed");
}
