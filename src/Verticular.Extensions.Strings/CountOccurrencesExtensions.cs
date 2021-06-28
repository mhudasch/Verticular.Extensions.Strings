namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type regarding counting occurrences inside a string.
  /// </summary>
  public static class CountOccurencesExtensions
  {
    /// <summary>
    /// Counts the occurrence of a character inside a given string instance.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="searchValue">The character to search and count.</param>
    /// <returns>A positive number of occurrences or zero when the character cannot be found.</returns>
    public static int CountOccurrences(this string? value, char searchValue) =>
      value.CountOccurrences(searchValue, CharacterComparison.CurrentCulture);

    /// <summary>
    /// Counts the occurrence of a character inside a given string instance.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="searchValue">The character to search and count.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>A positive number of occurrences or zero when the character cannot be found.</returns>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="CharacterComparison" /> value.
    /// </exception>
    public static int CountOccurrences(this string? value, char searchValue, CharacterComparison comparisonType)
    {
      if (value is null || value.Length == 0)
      {
        return 0;
      }

      var comparer = CharacterComparer.FromComparison(comparisonType);
      var count = 0;
      foreach (var c in value.AsSpan())
      {
        if (comparer.Compare(c, searchValue) == 0)
        {
          count++;
        }
      }
      return count;
    }

    /// <summary>
    /// Counts the occurrence of a string inside a given string instance.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="searchValue">The string to search and count.</param>
    /// <returns>A positive number of occurrences or zero when the string cannot be found.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="searchValue" /> is <see langword="null" />.
    /// </exception>
    public static int CountOccurrences(this string? value, string searchValue) =>
      value.CountOccurrences(searchValue, StringComparison.CurrentCulture);

    /// <summary>
    /// Counts the occurrence of a string inside a given string instance.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="searchValue">The string to search and count.</param>
    /// <returns>A positive number of occurrences or zero when the string cannot be found.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="searchValue" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static int CountOccurrences(this string? value, string searchValue, StringComparison comparisonType)
    {
      if (value is null || value.Length == 0)
      {
        return 0;
      }

      if (searchValue is null)
      {
        throw new ArgumentNullException(nameof(searchValue));
      }

      // short-cut when searching for nothing
      if (searchValue.Length == 0)
      {
        return 0;
      }

      var count = 0;
      var index = 0;
      while ((index = value.IndexOf(searchValue, index, comparisonType)) != -1)
      {
        index += searchValue.Length;
        count++;
      }

      return count;
    }
  }
}
