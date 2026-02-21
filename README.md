# Flux.Mediator

**Flux.Mediator** is a lightweight, high‑performance mediator library
for .NET focused on clean architecture, explicit contracts, and zero
magic.

It provides in‑process request/response dispatching with strong typing,
DI integration --- designed to be
predictable, testable, and framework‑agnostic.

---

## Features

- **Request / Response model**
- **Notification model**
- **Strongly typed handlers**
- **Thread-safe & stateless mediator**
- **Clean separation of Abstractions and Core**
- Designed for testability

---

## Packages

---

| Packages                                      | Description                               |
|-----------------------------------------------|-------------------------------------------|
|`Flux.Mediator.Abstractions`                   | Contracts (IRequest, IMediator, Handlers) |
|`Flux.Mediator.Core`                           | Mediator implementation                   |
|`Flux.Mediator.Extensions.DependencyInjection` | Developer Experience (DX)                 |

---

## Installation

```bash
dotnet add package Flux.Mediator
```

---

## Basic Concepts

### Request

```csharp
public record PingRequest : IRequest<string>;
```

### Notification

```csharp
public record Notification(string Message) : INotification;
```

### Handlers

```csharp
public sealed class PingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => Task.FromResult("pong");
}
```

```csharp
public sealed class NotificationHandler : INotificationHandler<Notification>
{
    public async Task HandleAsync(Notification notification, CancellationToken ct)
        => Console.WriteLine($"A notification received - {notification.Message}");
}
```

### Registering Handlers

```csharp
services.AddTransient<IRequestHandler<PingRequest, string>, PingRequestHandler>();
services.AddTransient<INotificationHandler<Notification>, NotificationHandler>();
```

### Registering the Mediator

```csharp
services.AddFluxMediator();
```

### Using the Mediator

#### Request

```csharp
var result = await mediator.SendAsync(new PingRequest());
```

#### Notification

```csharp
await mediator.PublishAsync(new Notification("You have a message."));
```

---

## Architecture Goals

Flux.Mediator is built around:

- Explicit contracts
- No hidden service locators
- Predictable execution flow
- High performance without sacrificing readability
- Compatibility with Clean Architecture, DDD and CQRS patterns

---

## Benchmarks

```

BenchmarkDotNet v0.15.8, Linux Debian GNU/Linux 13 (trixie)
Intel Xeon CPU E5-2680 v4 2.40GHz, 1 CPU, 28 logical and 14 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3


```
| Method       | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------- |----------:|---------:|---------:|-------:|----------:|
| Request      |  95.21 ns | 0.557 ns | 0.465 ns | 0.0105 |     192 B |
| Notification | 127.48 ns | 1.142 ns | 1.068 ns | 0.0153 |     280 B |

---

## Testing

The mediator is designed to be tested in isolation:

```csharp
var result = await mediator.SendAsync(new PingRequest());
Assert.Equal("pong", result);
```

---

## Versioning

Flux.Mediator follows **Semantic Versioning**:

- **MAJOR** → breaking changes
- **MINOR** → new features without breaking
- **PATCH** → fixes

---

### NuGet

NuGet Package - [Flux.Mediator](https://www.nuget.org/packages/Flux.Mediator)

## Author

Miguel Magno
