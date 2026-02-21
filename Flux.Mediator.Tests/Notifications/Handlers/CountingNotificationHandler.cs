using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Tests.Shared.Counters;

namespace Flux.Mediator.Tests.Notifications.Handlers;

public sealed class CountingNotificationHandler(Counter counter) : INotificationHandler<CountedNotification>
{
    public Task HandleAsync(CountedNotification notification, CancellationToken ct = default)
    {
        counter.Increment();
        return Task.CompletedTask;
    }
}