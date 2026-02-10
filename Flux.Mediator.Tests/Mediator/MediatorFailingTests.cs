using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Handlers;
using Flux.Mediator.Tests.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Mediator;

public class MediatorFailingTests
{
    [Fact]
    public async Task SendAsync_ShouldPropagateHandlerException()
    {
        var services = new ServiceCollection();
        services.AddFluxMediator();
        services.AddTransient<IRequestHandler<PingRequest, string>, FailingRequestHandler>();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            mediator.SendAsync(new PingRequest()));
    }
}
