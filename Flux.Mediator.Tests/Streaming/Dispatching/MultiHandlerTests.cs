using Flux.Mediator.Abstractions.Streaming;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Streaming.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Streaming.Dispatching;

public class MultiHandlerTests
{
    [Fact]
    public void AddFluxMediator_ShouldThrow_WhenMultipleHandlersRegistered()
    {
        var services = new ServiceCollection();

        services.AddTransient<IStreamRequestHandler<NumberStreamRequest, int>, NumberStreamRequestHandler>();
        services.AddTransient<IStreamRequestHandler<NumberStreamRequest, int>, NumberStreamRequestHandler>();

        Assert.Throws<InvalidOperationException>(services.AddFluxMediator);
    }
}
