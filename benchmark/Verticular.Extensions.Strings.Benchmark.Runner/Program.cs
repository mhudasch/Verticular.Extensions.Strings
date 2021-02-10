namespace Verticular.Extensions.Strings.Benchmark.Runner
{
  using BenchmarkDotNet.Running;

  public class Program
  {
    public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(StringIsNullOrEmptyBenchmark).Assembly).Run(args);
  }
}
