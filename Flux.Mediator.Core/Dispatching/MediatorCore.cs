using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Core.Notifications;
using Flux.Mediator.Core.Requests;

namespace Flux.Mediator.Core.Dispatching;

internal class MediatorCore(NotificationHandlerResolver notificationResolver, RequestHandlerResolver requestResolver) : IMediator
{
    public async Task PublishAsync(INotification notification, CancellationToken ct = default)
    {
        var handlers = notificationResolver.GetHandlers(notification.GetType());

        foreach (var handler in handlers)
            await handler.HandleAsync(notification, ct);
    }

    public Task<TResult> SendAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default)
    {
        var handler = requestResolver.GetHandler(request.GetType());

        return handler.HandleAsync(request, ct);
    }
}