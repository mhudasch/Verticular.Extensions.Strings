namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type regarding string content.
  /// </summary>
  public static class StringContainsExtensions
  {
    /// <summary>
    /// Returns a value indicating whether any of the specified characters occurs within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> of the specified characters occurs within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    public static bool ContainsAny(this string? value, params char[] characters) =>
      value.ContainsAny(CharacterComparison.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether any of the specified characters occurs within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> of the specified characters occurs within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="characters" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="CharacterComparison" /> value.
    /// </exception>
    public static bool ContainsAny(this string? value, CharacterComparison comparisonType, params char[] characters)
    {
      if (value is null)
      {
        return false;
      }

      if (characters is null)
      {
        throw new ArgumentNullException(nameof(characters));
      }

      var comparer = CharacterComparer.FromComparison(comparisonType);

      if (characters.Length == 0)
      {
        return false;
      }

      foreach (var t in characters)
      {
        foreach (var c in value.AsSpan())
        {
          if (comparer.Compare(c, t) == 0)
          {
            return true;
          }
        }
      }

      return false;
    }

    /// <summary>
    /// Returns a value indicating whether all of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <returns>
    /// <see langword="true" /> if <i>all</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="characters" /> is <see langword="null" />.
    /// </exception>
    public static bool ContainsAll(this string? value, params char[] characters) =>
      value.ContainsAll(CharacterComparison.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether all of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>all</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="characters" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="CharacterComparison" /> value.
    /// </exception>
    public static bool ContainsAll(this string? value, CharacterComparison comparisonType, params char[] characters)
    {
      if (value is null)
      {
        return false;
      }

      if (characters is null)
      {
        throw new ArgumentNullException(nameof(characters));
      }

      var characterComparer = CharacterComparer.FromComparison(comparisonType);

      if (characters.Length == 0)
      {
        return false;
      }

      // implementation that avoid allocation of extra strings or char arrays
      // but pay for that by double iterating over string length item at worst case
      var lookup = new bool[characters.Length];
      for (var i = 0; i < characters.Length; i++)
      {
        foreach (var c in value.AsSpan())
        {
          if (characterComparer.Compare(c, characters[i]) == 0)
          {
            lookup[i] = true;
          }
        }
      }

      for (var i = 0; i < characters.Length; i++)
      {
        if (!lookup[i])
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Returns a value indicating whether none of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <returns>
    /// <see langword="true" /> if <i>none</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="characters" /> is <see langword="null" />.
    /// </exception>
    public static bool ContainsNone(this string? value, params char[] characters) =>
      !value.ContainsAny(CharacterComparison.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether none of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>
    /// <see langword="true" /> if <i>none</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="characters" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="CharacterComparison" /> value.
    /// </exception>
    public static bool ContainsNone(this string? value, CharacterComparison comparisonType, params char[] characters) =>
      !value.ContainsAny(comparisonType, characters);
  }
}
