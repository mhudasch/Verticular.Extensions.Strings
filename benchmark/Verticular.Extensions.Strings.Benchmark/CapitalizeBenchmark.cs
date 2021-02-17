namespace Verticular.Extensions.Strings.Benchmark
{
  using System;
  using BenchmarkDotNet.Attributes;
  using BenchmarkDotNet.Jobs;

  //[SimpleJob(RuntimeMoniker.Net461)]
  //[SimpleJob(RuntimeMoniker.Net462)]
  //[SimpleJob(RuntimeMoniker.Net47)]
  //[SimpleJob(RuntimeMoniker.Net471)]
  //[SimpleJob(RuntimeMoniker.Net472)]
  //[SimpleJob(RuntimeMoniker.Net48)]
  [SimpleJob(RuntimeMoniker.NetCoreApp21)] // LTS
  [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)] // LTS
  [SimpleJob(RuntimeMoniker.NetCoreApp50)]
  [MemoryDiagnoser]
  [HtmlExporter]
  public class CapitalizeBenchmark
  {
    [Params("", "A", "a", "uncapitalized")]
    public string Data { get; set; } = "";

    [Benchmark(Baseline = true)]
    public string Native()
    {
      if(this.Data.Length == 0)
      {
        return this.Data;
      }

      if(this.Data.Length == 1)
      {
        return char.ToUpper(this.Data[0]).ToString();
      }

      return char.ToUpper(this.Data[0]) + this.Data.Substring(1);
    }

    [Benchmark]
    public string Stackalloc()
    {
      if(this.Data.Length == 0)
      {
        return this.Data;
      }

      if (this.Data.Length == 1)
      {
        return char.ToUpper(this.Data[0]).ToString();
      }

      Span<char> buffer = stackalloc char[this.Data.Length];
      this.Data.AsSpan().CopyTo(buffer);
      buffer[0] = char.ToUpper(buffer[0]);
      return buffer.ToString();
    }

    [Benchmark]
    public string StringCreate()
    {
      if (this.Data.Length == 0)
      {
        return this.Data;
      }

      if (this.Data.Length == 1)
      {
        return char.ToUpper(this.Data[0]).ToString();
      }

      return string.Create(this.Data.Length, this.Data, (span, state) =>
      {
        span[0] = char.ToUpper(state[0]);
        state.AsSpan().Slice(1).CopyTo(span.Slice(1));
      });
    }
  }
}
