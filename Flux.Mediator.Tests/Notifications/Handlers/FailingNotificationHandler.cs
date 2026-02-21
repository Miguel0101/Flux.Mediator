using Flux.Mediator.Abstractions.Notifications;

namespace Flux.Mediator.Tests.Notifications.Handlers;

public sealed class FailingNotificationHandler : INotificationHandler<NotificationReceived>
{
    public Task HandleAsync(NotificationReceived notification, CancellationToken ct = default)
    {
        throw new ApplicationException("BOOM!");
    }
}