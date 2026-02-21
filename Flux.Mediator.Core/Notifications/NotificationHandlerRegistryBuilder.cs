using Flux.Mediator.Abstractions.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Core.Notifications;

internal static class NotificationHandlerRegistryBuilder
{
    public static NotificationHandlerRegistry Build(IServiceCollection services)
    {
        var registry = new NotificationHandlerRegistry();

        var handlers = services
            .Where(descriptor => descriptor.ServiceType.IsGenericType &&
                descriptor.ServiceType.GetGenericTypeDefinition() == typeof(INotificationHandler<>));

        foreach (var descriptor in handlers)
        {
            var notificationType = descriptor.ServiceType.GetGenericArguments()[0];
            registry.Register(notificationType, descriptor.ServiceType);
        }

        return registry;
    }
}