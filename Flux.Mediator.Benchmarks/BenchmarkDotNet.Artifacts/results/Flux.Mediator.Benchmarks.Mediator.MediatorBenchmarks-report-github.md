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
