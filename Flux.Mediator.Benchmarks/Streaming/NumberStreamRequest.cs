using Flux.Mediator.Abstractions.Streaming;

namespace Flux.Mediator.Benchmarks.Streaming;

public record NumberStreamRequest(int Count) : IStreamRequest<int>;
