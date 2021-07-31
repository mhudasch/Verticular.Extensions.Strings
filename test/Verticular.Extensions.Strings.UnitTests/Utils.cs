namespace Verticular.Extensions.Strings.UnitTests
{
#if !(NET45 || NET451 || NET452)
  using System;
#endif

  public static class EmptyArray
  {
    public static string[] OfString()
    {
      return
#if NET45 || NET451 || NET452
new string[] { };
#else
Array.Empty<string>();
#endif
    }

    public static char[] OfChar()
    {
      return
#if NET45 || NET451 || NET452
new char[] { };
#else
Array.Empty<char>();
#endif
    }
  }
}
