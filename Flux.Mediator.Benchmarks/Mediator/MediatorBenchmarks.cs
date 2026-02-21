using BenchmarkDotNet.Attributes;
using Flux.Mediator.Abstractions.Dispatching;
using Flux.Mediator.Abstractions.Notifications;
using Flux.Mediator.Abstractions.Requests;
using Flux.Mediator.Benchmarks.Handlers;
using Flux.Mediator.Benchmarks.Notifications;
using Flux.Mediator.Benchmarks.Requests;
using Flux.Mediator.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Mediator.Benchmarks.Mediator;

[MemoryDiagnoser]
public class MediatorBenchmarks
{
    private IMediator _mediator = default!;

    [GlobalSetup]
    public void Setup()
    {
        var services = new ServiceCollection();

        services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();
        services.AddTransient<INotificationHandler<Notification>, NotificationHandler>();
        services.AddFluxMediator();

        _mediator = services.BuildServiceProvider()
            .GetRequiredService<IMediator>();
    }

    [Benchmark]
    public Task<string> Request()
        => _mediator.SendAsync(new PingRequest());

    [Benchmark]
    public Task Notification()
        => _mediator.PublishAsync(new Notification());
}
