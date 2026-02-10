using Microsoft.Extensions.DependencyInjection;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Abstractions.Dispatching;

namespace Flux.Mediator.Tests;

public class MediatorMultipleHandlersTests
{
    public record Query : IRequest<int>;

    public sealed class Handler1 : IRequestHandler<Query, int>
    {
        public Task<int> HandleAsync(Query request, CancellationToken ct)
            => Task.FromResult(1);
    }

    public sealed class Handler2 : IRequestHandler<Query, int>
    {
        public Task<int> HandleAsync(Query request, CancellationToken ct)
            => Task.FromResult(2);
    }

    [Fact]
    public async Task SendAsync_WhenMultipleHandlersRegistered_Throws()
    {
        var services = new ServiceCollection();
        services.AddFluxMediator();

        services.AddTransient<IRequestHandler<Query, int>, Handler1>();
        services.AddTransient<IRequestHandler<Query, int>, Handler2>();

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<InvalidOperationException>(() => mediator.SendAsync(new Query()));
    }
}
