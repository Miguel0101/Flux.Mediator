namespace Flux.Mediator.Tests.Counters;

public sealed class Counter
{
    private int _count;

    public int Value => _count;

    public void Increment()
    {
        Interlocked.Increment(ref _count);
    }
}