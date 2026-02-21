using Flux.Mediator.Abstractions.Notifications;

namespace Flux.Mediator.Tests.Notifications.Handlers;

public record NotificationReceived(string Content) : INotification;