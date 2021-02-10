namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Contains matching utility methods that extend the <see cref="string" /> type.
  /// </summary>
  public static class StringMatchExtensions
  {
    /// <summary>
    /// Tests if a <see cref="string" /> only contains numbers. This might be helpful to validate order numbers or customer ids.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <remarks>
    /// This is not an attempt to parse the string into an integer, rather this method checks if each character is a
    /// number.
    /// </remarks>
    /// <returns><see langword="true" /> if the <see cref="string" /> only contains numbers.</returns>
    public static bool IsNumeric(this string? value)
    {
      // implementation that avoids allocations
      if (string.IsNullOrEmpty(value))
      {
        return false;
      }

      foreach (var c in value.AsSpan())
      {
        if (!char.IsDigit(c))
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Tests if a <see cref="string" /> only contains printable letters or numbers.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><see langword="true" /> if the <see cref="string" /> only contains letteres or numbers.</returns>
    public static bool IsAlphaNumeric(this string? value)
    {
      // implementation that avoids allocations
      if (string.IsNullOrEmpty(value))
      {
        return false;
      }

      foreach (var c in value.AsSpan())
      {
        if (!(char.IsDigit(c) || char.IsLetter(c)))
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Tests if a <see cref="string" /> is an email address.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><see langword="true" /> if the <see cref="string" /> is an email address.</returns>
    public static bool IsEmailAddress(this string? value)
    {
      if (value.IsNullOrWhiteSpace())
      {
        return false;
      }

      try
      {
        var _ = new System.Net.Mail.MailAddress(value);
        return true;
      }
      catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
      {
        return false;
      }
    }

    /// <summary>
    /// Tests if a <see cref="string" /> is an uri.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><see langword="true" /> if the <see cref="string" /> is an uri.</returns>
    public static bool IsUri(this string? value)
    {
      if (value.IsNullOrWhiteSpace())
      {
        return false;
      }

      try
      {
        var _ = new Uri(value);
        return true;
      }
      catch (UriFormatException)
      {
        return false;
      }
    }

    // TODO: add string.matches for to replace new regex.matches(pattern)
  }
}
