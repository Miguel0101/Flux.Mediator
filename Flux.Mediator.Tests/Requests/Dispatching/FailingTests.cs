using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Requests.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Requests.Dispatching;

public class FailingTests
{
    [Fact]
    public async Task SendAsync_ShouldPropagateHandlerException()
    {
        var services = new ServiceCollection();

        services.AddTransient<IRequestHandler<PingRequest, string>, FailingRequestHandler>();
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            mediator.SendAsync(new PingRequest()));
    }
}
