```

BenchmarkDotNet v0.15.8, Linux Debian GNU/Linux 13 (trixie)
Intel Xeon CPU E5-2680 v4 2.40GHz, 1 CPU, 28 logical and 14 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3


```
| Method   | Mean     | Error    | StdDev   | Gen0   | Allocated |
|--------- |---------:|---------:|---------:|-------:|----------:|
| SendPing | 67.73 ns | 0.226 ns | 0.189 ns | 0.0092 |     168 B |
