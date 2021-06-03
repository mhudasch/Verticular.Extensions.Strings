namespace Verticular.Extensions
{
  using System;
  using System.Text.RegularExpressions;

  /// <summary>
  /// Helps with matches against regular expressions.
  /// </summary>
  public static class RegularExpressionExtensions
  {
    /// <summary>
    /// Returns a value indicating whether a given string matches a regular expression pattern.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="pattern">Ther regular expression pattern to match.</param>
    /// <returns>
    /// <see langword="true"/> if the regular expression finds a match; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
    /// <exception cref="ArgumentNullException">The regular expression instance is null.</exception>
    public static bool IsMatch(this string? value, string pattern) =>
      value.IsMatch(new Regex(pattern, RegexOptions.None));

    /// <summary>
    /// Returns a value indicating whether a given string matches a regular expression pattern.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="pattern">Ther regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that modify the regular expression.</param>
    /// <returns>
    /// <see langword="true"/> if the regular expression finds a match; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
    /// <exception cref="ArgumentOutOfRangeException">options is not a valid <see cref="RegexOptions"/> value.</exception>
    /// <exception cref="ArgumentNullException">The regular expression instance is null.</exception>
    public static bool IsMatch(this string? value, string pattern, RegexOptions options) =>
      value.IsMatch(new Regex(pattern, options));

    /// <summary>
    /// Returns a value indicating whether a given string matches a regular expression pattern.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="pattern">Ther regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that modify the regular expression.</param>
    /// <param name="matchTimeout">A time-out interval, or <see cref="Regex.InfiniteMatchTimeout"/>
    /// to indicate that the method should not time out.</param>
    /// <returns>
    /// <see langword="true"/> if the regular expression finds a match; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
    /// <exception cref="ArgumentOutOfRangeException">options is not a valid <see cref="RegexOptions"/> value.</exception>
    /// <exception cref="ArgumentNullException">The regular expression instance is null.</exception>
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred. For more information about time-outs, see the Remarks section.</exception>
    public static bool IsMatch(this string? value, string pattern, RegexOptions options, TimeSpan matchTimeout) =>
      value.IsMatch(new Regex(pattern, options, matchTimeout));

    /// <summary>
    /// Returns a value indicating whether a given string matches the rules defined in the given <paramref name="regex"/>.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="regex">The <see cref="Regex"/> instance to match.</param>
    /// <returns>
    /// <see langword="true"/> if the regular expression finds a match; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">The regular expression instance is null.</exception>
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred. For more information about time-outs, see the Remarks section.</exception>
    public static bool IsMatch(this string? value, Regex regex)
    {
      if (value is null)
      {
        return false;
      }

      if (regex is null)
      {
        throw new ArgumentNullException(nameof(regex));
      }

      return regex.IsMatch(value!);
    }
  }
}
