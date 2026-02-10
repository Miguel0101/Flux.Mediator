using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests;

public class MediatorErrorTests
{
    public record Ping : IRequest<string>;

    [Fact]
    public async Task SendAsync_WhenNoHandlerRegistered_Throws()
    {
        var services = new ServiceCollection();
        services.AddFluxMediator();

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<InvalidOperationException>(() => mediator.SendAsync(new Ping()));
    }
}