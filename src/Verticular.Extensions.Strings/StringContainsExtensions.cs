namespace Verticular.Extensions
{
  using System;
  using System.Linq;

  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type regarding string content.
  /// </summary>
#if NETSTANDARD
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
  public static class StringContainsExtensions
  {

    /// <summary>
    /// Returns a value indicating whether any of the specified characters occurs within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <returns><see langword="true"/> if any of the specified characters occurs within the string; otherwise, <see langword="false" />.</returns>
    public static bool ContainsAny(this string value, params char[] characters) =>
      value.ContainsAny(CharacterComparer.CurrentCulure, characters);

    /// <summary>
    /// Returns a value indicating whether any of the specified characters occurs within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="characterComparer">The comparer used to find characters.</param>
    /// <returns><see langword="true"/> if any of the specified characters occurs within the string; otherwise, <see langword="false" />.</returns>
    public static bool ContainsAny(this string value, CharacterComparer characterComparer, params char[] characters)
    {
      if (value.IsNullOrEmpty())
      {
        return false;
      }

      if (characters is null)
      {
        throw new ArgumentNullException(nameof(characters));
      }

      if (characters.Length == 0)
      {
        throw new ArgumentOutOfRangeException(nameof(characters), "There must be at least one character given to seek in the string.");
      }

      return characters.Any(c => value.Contains(c, characterComparer));
    }

    /// <summary>
    /// Returns a value indicating whether all of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <returns><see langword="true"/> if all of the specified characters occur within the string; otherwise, <see langword="false" />.</returns>
    public static bool ContainsAll(this string value, params char[] characters) =>
      value.ContainsAll(CharacterComparer.CurrentCulure, characters);

    /// <summary>
    /// Returns a value indicating whether all of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="characterComparer">The comparer used to find characters.</param>
    /// <returns><see langword="true"/> if all of the specified characters occur within the string; otherwise, <see langword="false" />.</returns>
    public static bool ContainsAll(this string value, CharacterComparer characterComparer, params char[] characters)
    {
      if (value.IsNullOrEmpty())
      {
        return false;
      }

      if (characters is null)
      {
        throw new ArgumentNullException(nameof(characters));
      }

      if (characters.Length == 0)
      {
        throw new ArgumentOutOfRangeException(nameof(characters), "There must be at least one character given to seek in the string.");
      }

      return characters.All(c => value.Contains(c, characterComparer));
    }
  }
}
