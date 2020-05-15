namespace Verticular.Extensions
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type regarding string content.
  /// </summary>
#if NETSTANDARD
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
  public static class StringContainsExtensions
  {

    public static bool ContainsAny(this string value, IReadOnlyCollection<char> characters) =>
      value.ContainsAny(StringComparer.CurrentCulture, characters);

    public static bool ContainsAny(this string value, StringComparer characterComparer, IReadOnlyCollection<char> characters)
    {
      if (value.IsNullOrEmpty())
      {
        return false;
      }

      throw new NotImplementedException();

      for(var i = 0; i < value.Length; ++i)
      {
        
      }
    }

    public static bool ContainsAll(this string value, IReadOnlyCollection<char> characters) =>
      value.ContainsAll(StringComparer.CurrentCulture, characters);

    public static bool ContainsAll(this string value, StringComparer characterComparer, IReadOnlyCollection<char> characters)
    {
      if (value.IsNullOrEmpty())
      {
        return false;
      }

      throw new NotImplementedException();
    }
  }
}
