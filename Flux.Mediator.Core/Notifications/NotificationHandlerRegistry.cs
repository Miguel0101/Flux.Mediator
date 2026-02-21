namespace Flux.Mediator.Core.Notifications;

internal sealed class NotificationHandlerRegistry
{
    private readonly Dictionary<Type, List<Type>> _handlers = [];

    public void Register(Type notificationType, Type handlerType)
    {
        if (_handlers.TryGetValue(notificationType, out var handlers))
        {
            handlers.Add(handlerType);
            _handlers[notificationType] = handlers;
        }
        else
        {
            _handlers[notificationType] = [handlerType];
        }
    }

    public IReadOnlyDictionary<Type, List<Type>> Entries => _handlers;
}