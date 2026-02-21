namespace Flux.Mediator.Core.Requests;

internal sealed class RequestHandlerRegistry
{
    private readonly Dictionary<Type, Type> _handlers = [];

    public void Register(Type requestType, Type handlerType)
    {
        if (_handlers.ContainsKey(requestType))
            throw new InvalidOperationException($"Multiple handlers found for {requestType.Name}");

        _handlers[requestType] = handlerType;
    }

    public IReadOnlyDictionary<Type, Type> Entries => _handlers;
}