namespace Verticular.Extensions
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Helps with more checks against multiple values.
  /// </summary>
  public static class StringEqualsExtensions
  {
    /// <summary>
    /// Checks whether or not a given string equals <i>any</i> string in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    public static bool EqualsAny(this string? value, params string[] matchSet) =>
      value.EqualsAny((IEnumerable<string>)matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>any</i> string in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="matchSet" /> is <see langword="null" />.
    /// </exception>
    public static bool EqualsAny(this string? value, IEnumerable<string> matchSet) =>
      value.EqualsAny(StringComparison.Ordinal, matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>any</i> string in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static bool EqualsAny(this string? value, StringComparison comparisonType, params string[] matchSet) =>
      value.EqualsAny(comparisonType, (IEnumerable<string>)matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>any</i> string in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="matchSet" /> is <see langword="null" />.
    /// </exception>
    public static bool EqualsAny(this string? value, StringComparison comparisonType, IEnumerable<string> matchSet)
    {
      if (value is null || value.Length == 0)
      {
        return false;
      }

      if (matchSet is null)
      {
        throw new ArgumentNullException(nameof(matchSet));
      }

      //TODO: try span of t implementation here also to avoid linq
      return matchSet.Any(s => s.Equals(value, comparisonType));
    }

    /// <summary>
    /// Checks whether or not a given string equals <i>none</i> of the strings in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <returns>
    /// <see langword="true" /> if <i>no</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    public static bool EqualsNone(this string? value, params string[] matchSet) =>
      value.EqualsNone((IEnumerable<string>)matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>none</i> of the strings in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <returns>
    /// <see langword="true" /> if <i>no</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="matchSet" /> is <see langword="null" />.
    /// </exception>
    public static bool EqualsNone(this string? value, IEnumerable<string> matchSet) =>
      value.EqualsNone(StringComparison.Ordinal, matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>none</i> of the strings in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>no</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static bool EqualsNone(this string? value, StringComparison comparisonType, params string[] matchSet) =>
      value.EqualsNone(comparisonType, (IEnumerable<string>)matchSet);

    /// <summary>
    /// Checks whether or not a given string equals <i>none</i> of the strings in a given set.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="matchSet">The set of available strings to test against.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>no</i> string in the given set equals the given value; otherwise
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="matchSet" /> is <see langword="null" />.
    /// </exception>
    public static bool EqualsNone(this string? value, StringComparison comparisonType, IEnumerable<string> matchSet)
    {
      if (value is null || value.Length == 0)
      {
        return false;
      }
       
      return !value.EqualsAny(comparisonType, matchSet);
    }
  }
}
