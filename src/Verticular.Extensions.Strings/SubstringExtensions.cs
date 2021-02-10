namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Simplifies some of the Substring apis into short-cut-methods.
  /// </summary>
  public static class SubstringExtensions
  {
    public static string Until(this string? value, string match) =>
      value.Until(match, StringComparison.CurrentCulture);

    public static string Until(this string? value, string match, StringComparison comparisonType)
    {
      if (value is null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      if (match is null)
      {
        throw new ArgumentNullException(nameof(match));
      }

      var matchIndex = value.IndexOf(match, comparisonType);
      if(matchIndex < 0)
      {
        return value;
      }

      return value.Substring(0, matchIndex);
    }

    //public static string Until(this string? value, char match) =>
    //   value.Until(match, CharacterComparer.CurrentCulure);

    //public static string Until(this string? value, char match, CharacterComparer comparisonType)
    //{

    //}
  }
}
