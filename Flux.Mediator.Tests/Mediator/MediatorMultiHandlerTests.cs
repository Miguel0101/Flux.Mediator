using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Handlers;
using Flux.Mediator.Tests.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Mediator;

public class MediatorMultiHandlerTests
{
    [Fact]
    public async Task SendAsync_ShouldThrow_WhenMultipleHandlersRegistered()
    {
        var services = new ServiceCollection();

        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();
        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();

        Assert.Throws<InvalidOperationException>(services.AddFluxMediator);
    }
}
