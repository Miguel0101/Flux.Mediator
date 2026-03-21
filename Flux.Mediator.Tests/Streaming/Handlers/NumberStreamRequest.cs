using Flux.Mediator.Abstractions.Streaming;

namespace Flux.Mediator.Tests.Streaming.Handlers;

public record NumberStreamRequest(int Count) : IStreamRequest<int>;
