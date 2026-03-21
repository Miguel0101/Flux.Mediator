```

BenchmarkDotNet v0.15.8, Linux Debian GNU/Linux 13 (trixie)
Intel Xeon CPU E5-2680 v4 2.40GHz, 1 CPU, 28 logical and 14 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3


```
| Method       | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------- |---------:|---------:|---------:|-------:|----------:|
| Request      | 96.42 ns | 0.521 ns | 0.435 ns | 0.0105 |     192 B |
| Notification | 87.55 ns | 0.613 ns | 0.544 ns | 0.0061 |     112 B |
| Streaming    | 78.88 ns | 1.154 ns | 0.964 ns | 0.0095 |     176 B |
