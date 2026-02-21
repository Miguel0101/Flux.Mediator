using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Abstractions.Requests;

namespace Flux.Mediator.Abstractions.Dispatching;

public interface IMediator
{
    Task<TResult> SendAsync<TResult>(IRequest<TResult> request, CancellationToken ct = default);
    Task PublishAsync(INotification notification, CancellationToken ct = default);
}