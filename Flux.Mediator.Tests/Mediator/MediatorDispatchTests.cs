using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Handlers;
using Flux.Mediator.Tests.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Mediator;

public class MediatorDispatchTests
{
    [Fact]
    public async Task SendAsync_ShouldReturnResponse_FromRequestHandler()
    {
        var services = new ServiceCollection();

        services.AddFluxMediator();
        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var result = await mediator.SendAsync(new PingRequest());

        Assert.Equal("pong", result);
    }
}
