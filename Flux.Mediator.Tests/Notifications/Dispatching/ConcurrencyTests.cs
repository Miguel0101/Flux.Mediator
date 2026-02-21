using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Notifications.Handlers;
using Flux.Mediator.Tests.Shared.Counters;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Notifications.Dispatching;

public class ConcurrencyTests
{
    [Fact]
    public async Task PublishAsync_ShouldBeThreadSafe_UnderHighConcurrency()
    {
        var services = new ServiceCollection();
        int handlersPerNotification = 100;
        int concurrentNotifications = 100;

        services.AddSingleton<Counter>();

        for (int i = 0; i < handlersPerNotification; i++)
            services.AddTransient<INotificationHandler<CountedNotification>, CountingNotificationHandler>();

        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();
        var counter = provider.GetRequiredService<Counter>();

        var tasks = Enumerable.Range(0, concurrentNotifications)
            .Select(task => mediator.PublishAsync(new CountedNotification()));

        await Task.WhenAll(tasks);

        int expected = handlersPerNotification * concurrentNotifications;

        Assert.Equal(expected, counter.Value);
    }
}