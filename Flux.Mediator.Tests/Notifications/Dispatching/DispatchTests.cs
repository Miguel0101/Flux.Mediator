using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Notifications.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Notifications.Dispatching;

public class DispatchTests
{
    [Fact]
    public async Task PublishAsync_ShouldDispatchNotifications_FromNotificationHandler()
    {
        var services = new ServiceCollection();
        var handler = new NotificationListenerHandler();

        services.AddSingleton<INotificationHandler<NotificationReceived>>(handler);
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        List<string> messages = ["Hello, I'm a notification!", "Use Flux Mediator!", "It's free."];

        foreach (var message in messages)
            await mediator.PublishAsync(new NotificationReceived(message));

        Assert.Equal(messages.Count, handler.Notifications.Count);
        Assert.All(messages, message => Assert.Contains(message, handler.Notifications));
    }
}