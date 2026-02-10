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
- **Strongly typed handlers**
- **Thread-safe & stateless mediator**
- **Clean separation of Abstractions and Core**
- Designed for testability

---

## Packages

---

Package Responsibility

---

`Flux.Mediator.Abstractions` Contracts (IRequest, IMediator, Handlers)

`Flux.Mediator.Core` Mediator implementation

`Flux.Mediator.Extensions.DependencyInjection` Developer Experience (DX)

---

## Installation

```bash
dotnet add package Flux.Mediator
```

---

## Basic Concepts

### Request

```csharp
public sealed class PingRequest : IRequest<string>;
```

### Handler

```csharp
public sealed class PingRequestHandler : IRequestHandler<PingRequest, string>
{
    public Task<string> HandleAsync(PingRequest request, CancellationToken ct)
        => Task.FromResult("pong");
}
```

### Using the Mediator

```csharp
var result = await mediator.SendAsync(new PingRequest());
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
.NET SDK 10.0.102
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method   | Mean     | Error   | StdDev  | Gen0   | Allocated |
|--------- |---------:|--------:|--------:|-------:|----------:|
| SendPing | 937.9 ns | 4.31 ns | 3.82 ns | 0.0343 |     632 B |


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

## Author

Miguel Magno
