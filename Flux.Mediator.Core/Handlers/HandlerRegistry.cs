namespace Flux.Mediator.Core.Handlers;

internal sealed class HandlerRegistry
{
    private readonly Dictionary<Type, Type> _requestToHandlerInterface = [];

    public void Register(Type requestType, Type handlerInterfaceType)
    {
        if (_requestToHandlerInterface.GetValueOrDefault(requestType) is not null)
            throw new InvalidOperationException($"Multiple handlers found for {requestType.Name}");

        _requestToHandlerInterface[requestType] = handlerInterfaceType;
    }

    public IReadOnlyDictionary<Type, Type> Entries => _requestToHandlerInterface;
}