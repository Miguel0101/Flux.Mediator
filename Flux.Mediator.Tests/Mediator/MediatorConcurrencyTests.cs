using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Handlers;
using Flux.Mediator.Tests.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Mediator;

public class MediatorConcurrencyTests
{
    [Fact]
    public async Task SendAsync_ShouldBeThreadSafe()
    {
        CountingRequestHandler.Count = 0;

        var services = new ServiceCollection();
        services.AddFluxMediator();
        services.AddTransient<IRequestHandler<PingRequest, string>, CountingRequestHandler>();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var tasks = Enumerable.Range(0, 100)
            .Select(_ => mediator.SendAsync(new PingRequest()));

        await Task.WhenAll(tasks);

        Assert.Equal(100, CountingRequestHandler.Count);
    }
}
