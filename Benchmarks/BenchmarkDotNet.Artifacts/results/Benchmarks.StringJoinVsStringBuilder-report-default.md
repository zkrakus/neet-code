
BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


 Method             | Mean     | Error   | StdDev  | Gen0   | Allocated |
------------------- |---------:|--------:|--------:|-------:|----------:|
 UsingStringJoin    | 397.9 ns | 4.81 ns | 4.50 ns | 0.0839 |     704 B |
 UsingStringBuilder | 181.6 ns | 3.53 ns | 3.13 ns | 0.0515 |     432 B |
