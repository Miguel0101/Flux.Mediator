using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Requests.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Requests.Dispatching;

public class MultiHandlerTests
{
    [Fact]
    public async Task AddFluxMediator_ShouldThrow_WhenMultipleHandlersRegistered()
    {
        var services = new ServiceCollection();

        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();
        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();

        Assert.Throws<InvalidOperationException>(services.AddFluxMediator);
    }
}
