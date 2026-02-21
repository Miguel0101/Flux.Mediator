namespace Flux.Mediator.Abstractions.Notifications;

public interface INotificationHandler<TNotification> : IDynamicNotificationHandler
    where TNotification : INotification
{
    Task HandleAsync(TNotification notification, CancellationToken ct = default);

    Task IDynamicNotificationHandler.HandleAsync(INotification notification, CancellationToken ct)
        => HandleAsync((TNotification)notification, ct);
}