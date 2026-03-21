using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Streaming;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Streaming.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Streaming.Dispatching;

public class FailingTests
{
    [Fact]
    public async Task Stream_ShouldPropagateHandlerException()
    {
        var services = new ServiceCollection();

        services.AddTransient<IStreamRequestHandler<NumberStreamRequest, int>, FailingNumberStreamRequestHandler>();
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await foreach (var _ in mediator.Stream(new NumberStreamRequest(2)));
        });
    }
}
