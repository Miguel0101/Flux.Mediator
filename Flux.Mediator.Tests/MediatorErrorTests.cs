using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions;

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