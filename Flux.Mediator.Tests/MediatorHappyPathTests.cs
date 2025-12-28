using Flux.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests;

public class MediatorHappyPathTests
{
    public record CountCharactersRequest(string Content) : IRequest<int>;

    public sealed class Handler : IRequestHandler<CountCharactersRequest, int>
    {
        public override Task<int> HandleAsync(CountCharactersRequest request, CancellationToken ct = default)
            => Task.FromResult(request.Content.Length);
    }

    [Fact]
    public async Task SendAsync_WhenHandlerExists_ReturnsExpectedResult()
    {
        var services = new ServiceCollection();

        services.AddFluxMediator();
        services.AddTransient<IRequestHandler<CountCharactersRequest, int>, Handler>();

        using var provider = services.BuildServiceProvider();

        var mediator = provider.GetRequiredService<IMediator>();

        var result = await mediator.SendAsync(
            new CountCharactersRequest("Hello World!"));

        Assert.Equal(12, result);
    }
}
