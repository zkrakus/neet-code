using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkRunner.Run<StringJoinVsStringBuilder>();