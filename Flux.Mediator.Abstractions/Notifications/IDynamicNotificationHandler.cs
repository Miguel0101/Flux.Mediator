namespace Flux.Mediator.Abstractions.Notifications;

public interface IDynamicNotificationHandler
{
    Task HandleAsync(INotification notification, CancellationToken ct = default);
}