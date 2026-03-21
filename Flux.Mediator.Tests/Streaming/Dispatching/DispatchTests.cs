using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Streaming;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Streaming.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Streaming.Dispatching;

public class DispatchTests
{
    [Fact]
    public async Task Stream_ShouldReturnSequence_FromStreamRequestHandler()
    {
        var services = new ServiceCollection();

        services.AddTransient<IStreamRequestHandler<NumberStreamRequest, int>, NumberStreamRequestHandler>();
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var results = new List<int>();
        await foreach (var value in mediator.Stream(new NumberStreamRequest(5)))
        {
            results.Add(value);
        }

        Assert.Equal([1, 2, 3, 4, 5], results);
    }
}
