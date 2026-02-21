using Flux.Mediator.Abstractions.Requests;

namespace Flux.Mediator.Tests.Requests.Handlers;

public record PingRequest : IRequest<string>;
