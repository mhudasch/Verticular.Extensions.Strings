namespace Verticular.Extensions.Strings.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using BenchmarkDotNet.Jobs;

  [SimpleJob(RuntimeMoniker.Net461)]
  [SimpleJob(RuntimeMoniker.Net462)]
  [SimpleJob(RuntimeMoniker.Net47)]
  [SimpleJob(RuntimeMoniker.Net471)]
  [SimpleJob(RuntimeMoniker.Net472)]
  [SimpleJob(RuntimeMoniker.Net48)]
  [SimpleJob(RuntimeMoniker.NetCoreApp21)] // LTS
  [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)] // LTS
  [SimpleJob(RuntimeMoniker.NetCoreApp50)]
  [HtmlExporter]
  public class StringIsNullOrEmptyBenchmark
  {
    [Params("" /*empty*/, (string?)null, "This is the test string.")]
    public string? Data { get; set; }

    [Benchmark(Baseline = true)]
    public bool Native() => string.IsNullOrEmpty(Data);

    [Benchmark]
    public bool Wrapped() => Data.IsNullOrEmpty();
  }
}
