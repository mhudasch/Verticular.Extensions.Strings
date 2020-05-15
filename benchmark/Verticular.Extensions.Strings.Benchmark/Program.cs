namespace Verticular.Extensions.Strings.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using BenchmarkDotNet.Running;

  class Program
  {
    static void Main(string[] args)
    {
      var summary = BenchmarkRunner.Run<StringIsNullOrEmptyBenchmark>();
    }
  }

  public class StringIsNullOrEmptyBenchmark
  {
    private const string Data = "Hello World";

    public StringIsNullOrEmptyBenchmark()
    {
    }

    [Benchmark]
    public bool Native() => string.IsNullOrEmpty(Data);

    [Benchmark]
    public bool Wrapped() => Data.IsNullOrEmpty();
  }
}
