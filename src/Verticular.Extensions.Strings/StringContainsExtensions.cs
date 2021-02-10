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
    public static bool ContainsAny(this string value, params char[] characters) =>
      value.ContainsAny(CharacterComparer.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether any of the specified characters occurs within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="characterComparer">The comparer used to find characters.</param>
    /// <returns>
    /// <see langword="true" /> if <i>any</i> of the specified characters occurs within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
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

      if (characterComparer is null)
      {
        throw new ArgumentNullException(nameof(characterComparer));
      }

      if (characters.Length == 0)
      {
        return false;
      }

      foreach (var t in characters)
      {
        foreach (var c in value.AsSpan())
        {
          if (characterComparer.Compare(c, t) == 0)
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
    public static bool ContainsAll(this string value, params char[] characters) =>
      value.ContainsAll(CharacterComparer.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether all of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="characterComparer">The comparer used to find characters.</param>
    /// <returns>
    /// <see langword="true" /> if <i>all</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
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

      if (characterComparer is null)
      {
        throw new ArgumentNullException(nameof(characterComparer));
      }

      if (characters.Length == 0)
      {
        return false;
      }

      // implementation that avoid allocation of extra strings or char arrays
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
        if (lookup[i] == false)
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
    public static bool ContainsNone(this string value, params char[] characters) =>
      !value.ContainsAny(CharacterComparer.CurrentCulture, characters);

    /// <summary>
    /// Returns a value indicating whether none of the specified characters occur within this string.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="characters">The characters to seek.</param>
    /// <param name="characterComparer">The comparer used to find characters.</param>
    /// <returns>
    /// <see langword="true" /> if <i>none</i> of the specified characters occur within the string; otherwise,
    /// <see langword="false" />.
    /// </returns>
    public static bool ContainsNone(this string value, CharacterComparer characterComparer, params char[] characters) =>
      !value.ContainsAny(characterComparer, characters);
  }
}
