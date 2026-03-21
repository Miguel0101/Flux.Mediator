using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Streaming;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Shared.Counters;
using Flux.Mediator.Tests.Streaming.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Streaming.Dispatching;

public class ConcurrencyTests
{
    [Fact]
    public async Task Stream_ShouldBeThreadSafe()
    {
        var services = new ServiceCollection();

        services.AddSingleton<Counter>();
        services.AddTransient<IStreamRequestHandler<NumberStreamRequest, int>, CountingNumberStreamRequestHandler>();
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();
        var counter = provider.GetRequiredService<Counter>();

        var tasks = Enumerable.Range(0, 100)
            .Select(async _ =>
            {
                await foreach (var _value in mediator.Stream(new NumberStreamRequest(1)));
            });

        await Task.WhenAll(tasks);

        Assert.Equal(100, counter.Value);
    }
}
