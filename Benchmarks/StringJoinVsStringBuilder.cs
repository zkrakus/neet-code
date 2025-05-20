using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using System.Text;

namespace Benchmarks;

[MemoryDiagnoser]
[Config(typeof(MarkdownConfig))]
public class StringJoinVsStringBuilder
{
    private readonly int[] data = Enumerable.Range(0, 26).ToArray();

    [Benchmark]
    public string UsingStringJoin()
    {
        return string.Join("|", data);
    }

    [Benchmark]
    public string UsingStringBuilder()
    {
        var sb = new StringBuilder(100);
        for (int i = 0; i < data.Length; i++)
        {
            sb.Append(data[i]);
            sb.Append('|');
        }
        return sb.ToString();
    }

    private class MarkdownConfig : ManualConfig
    {
        public MarkdownConfig()
        {
            AddExporter(MarkdownExporter.Default);
        }
    }
}