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
