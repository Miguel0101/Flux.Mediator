using System.Collections.Concurrent;
using Flux.Mediator.Abstractions.Notifications;

namespace Flux.Mediator.Tests.Notifications.Handlers;

public sealed class NotificationListenerHandler : INotificationHandler<NotificationReceived>
{
    public ConcurrentQueue<string> Notifications = [];

    public Task HandleAsync(NotificationReceived notification, CancellationToken ct = default)
    {
        Notifications.Enqueue(notification.Content);
        return Task.CompletedTask;
    }
}