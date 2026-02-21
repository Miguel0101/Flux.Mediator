using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Benchmarks.Notifications;

namespace Flux.Mediator.Benchmarks.Handlers;

public sealed class NotificationHandler : INotificationHandler<Notification>
{
    public Task HandleAsync(Notification notification, CancellationToken ct = default)
        => Task.CompletedTask;
}