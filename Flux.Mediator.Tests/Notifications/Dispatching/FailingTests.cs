using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Extensions.DependencyInjection;
using Flux.Mediator.Tests.Notifications.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Tests.Notifications.Dispatching;

public sealed class FailingTests
{
    [Fact]
    public async Task PublishAsync_ShouldPropagateHandlerException()
    {
        var services = new ServiceCollection();

        services.AddTransient<INotificationHandler<NotificationReceived>, FailingNotificationHandler>();
        services.AddFluxMediator();

        await using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        await Assert.ThrowsAsync<ApplicationException>(() => mediator.PublishAsync(new NotificationReceived("Use Flux Mediator!")));
    }
}