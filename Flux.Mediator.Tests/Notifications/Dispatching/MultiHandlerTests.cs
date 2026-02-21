using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Notifications.Handlers;
using Flux.Mediator.Tests.Shared.Counters;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Notifications.Dispatching;

public class MultiHandlerTests
{
    [Fact]
    public async Task PublishAsync_ShouldDispatch_WhenMultipleHandlersRegistered()
    {
        var services = new ServiceCollection();
        int handlers = 10;

        services.AddSingleton<Counter>();

        for (int i = 0; i < handlers; i++)
            services.AddTransient<INotificationHandler<CountedNotification>, CountingNotificationHandler>();

        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();
        var counter = provider.GetRequiredService<Counter>();

        await mediator.PublishAsync(new CountedNotification());

        Assert.Equal(handlers, counter.Value);
    }
}