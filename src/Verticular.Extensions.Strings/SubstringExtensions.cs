namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Simplifies some of the Substring apis into short-cut-methods.
  /// </summary>
  public static class SubstringExtensions
  {
    /// <summary>
    /// Gets the beginning of a string value until the <i>first</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="match" /> is <see langword="null" />.
    /// </exception>
    public static string Until(this string? value, string match) =>
      value.Until(match, StringComparison.CurrentCulture);

    /// <summary>
    /// Gets the beginning of a string value until the <i>first</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="match" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
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

      var spannedValue = value.AsSpan();
      var spannedMatch = match.AsSpan();

      // do not allocate only find a window of match inside value
      var matchIndex = spannedValue.IndexOf(spannedMatch, comparisonType);
      if (matchIndex < 0)
      {
        return value;
      }

      // do not substring to avoid re-iterating from 0 to match-index 
      // just pointer slice the left side of the string and re-allocate 
      // into new string
      return spannedValue.Slice(0, matchIndex).ToString();
    }

    /// <summary>
    /// Gets the beginning of a string value until the <i>last</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="match" /> is <see langword="null" />.
    /// </exception>
    public static string UntilLast(this string? value, string match) =>
      value.UntilLast(match, StringComparison.CurrentCulture);

    /// <summary>
    /// Gets the beginning of a string value until the <i>last</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the string matching.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="match" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static string UntilLast(this string? value, string match, StringComparison comparisonType)
    {
      if (value is null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      if (match is null)
      {
        throw new ArgumentNullException(nameof(match));
      }

      var spannedValue = value.AsSpan();

      // span does not support LastIndexOf with StringComparison
      var matchIndex = value.LastIndexOf(match, comparisonType);
      if (matchIndex < 0)
      {
        return value;
      }

      // do not substring to avoid re-iterating from 0 to match-index 
      // just pointer slice the left side of the string and re-allocate 
      // into new string
      return spannedValue.Slice(0, matchIndex).ToString();
    }

    /// <summary>
    /// Gets the beginning of a string value until the <i>first</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    public static string Until(this string? value, char match) =>
      value.Until(match, CharacterComparison.CurrentCulture);

    /// <summary>
    /// Gets the beginning of a string value until the <i>first</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static string Until(this string? value, char match, CharacterComparison comparisonType)
    {
      if (value is null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      var characterComparer = CharacterComparer.FromComparison(comparisonType);
      var spannedValue = value.AsSpan();

      // do not allocate only find a window of match inside value
      var matchIndex = -1;
      var iterationIndex = 0;
      foreach (var c in spannedValue)
      {
        if (characterComparer.Compare(c, match) == 0)
        {
          matchIndex = iterationIndex;
          break;
        }
        iterationIndex++;
      }

      if (matchIndex < 0)
      {
        return value;
      }

      // do not substring to avoid re-iterating from 0 to match-index 
      // just pointer slice the left side of the string and re-allocate 
      // into new string
      return spannedValue.Slice(0, matchIndex).ToString();
    }

    /// <summary>
    /// Gets the beginning of a string value until the <i>last</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    public static string UntilLast(this string? value, char match) =>
      value.UntilLast(match, CharacterComparison.CurrentCulture);

    /// <summary>
    /// Gets the beginning of a string value until the <i>last</i> occurrence of the given <paramref name="match"/>
    /// or the whole string when the <paramref name="match"/> is not present.
    /// </summary>
    /// <param name="value">The value that might contain the match.</param>
    /// <param name="match">The string to search for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the character matching.</param>
    /// <returns>The sub-string from beginning till the found match or the whole string if the match is not present.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.
    /// </exception>
    public static string UntilLast(this string? value, char match, CharacterComparison comparisonType)
    {
      if (value is null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      var characterComparer = CharacterComparer.FromComparison(comparisonType);
      var spannedValue = value.AsSpan();

      // do not allocate only find a window of match inside value
      var matchIndex = -1;
      var iterationIndex = 0;
      foreach (var c in spannedValue)
      {
        if (characterComparer.Compare(c, match) == 0)
        {
          matchIndex = iterationIndex;
        }
        iterationIndex++;
      }

      if (matchIndex < 0)
      {
        return value;
      }

      // do not substring to avoid re-iterating from 0 to match-index 
      // just pointer slice the left side of the string and re-allocate 
      // into new string
      return spannedValue.Slice(0, matchIndex).ToString();
    }

    /// <summary>
    /// Capitalizes the first character in a string instance.
    /// </summary>
    /// <param name="value">The value that should be capitalized.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="value" /> is <see langword="null" />.
    /// </exception>
    public static string Capitalize(this string? value)
    {
      if (value is null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      if(value.Length == 0)
      {
        return value;
      }

      if(value.Length == 1)
      {
        return char.ToUpper(value[0]).ToString();
      }

#if NETSTANDARD_2_1
      return string.Create(this.Data.Length, this.Data, (span, state) =>
      {
        span[0] = char.ToUpper(state[0]);
        state.AsSpan().Slice(1).CopyTo(span.Slice(1));
      });
#else
      Span<char> buffer = stackalloc char[value.Length];
      value.AsSpan().CopyTo(buffer);
      buffer[0] = char.ToUpper(buffer[0]);
      return buffer.ToString();
#endif
    }
  }
}
