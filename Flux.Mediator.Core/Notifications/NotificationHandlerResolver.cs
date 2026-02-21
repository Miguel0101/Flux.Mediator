using Flux.Mediator.Abstractions.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Notifications;

internal sealed class NotificationHandlerResolver(IServiceProvider provider, NotificationHandlerRegistry registry)
{
    public List<IDynamicNotificationHandler> GetHandlers(Type notificationType)
    {
        if (!registry.Entries.TryGetValue(notificationType, out var handlerTypes))
            throw new InvalidOperationException(
                $"No handler registered for notification type '{notificationType.Name}'.");

        var handlers = new List<IDynamicNotificationHandler>(handlerTypes.Count);

        foreach (var handlerType in handlerTypes)
            handlers.Add((IDynamicNotificationHandler)provider.GetRequiredService(handlerType));

        return handlers;
    }
}