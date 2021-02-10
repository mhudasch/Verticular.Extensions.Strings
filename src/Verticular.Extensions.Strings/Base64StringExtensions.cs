namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type regarding base64.
  /// </summary>
  public static class Base64StringExtensions
  {
    // Characters that are used in base64 strings.
    private static readonly char[] Base64Chars =
    {
      'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
      'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
      'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'
    };

    // The checksum filler character
    private const char PaddingChar = '=';

    /// <summary>
    /// Tests whether a string is a valid base64 string.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns>True if the string is base64; otherwise false.</returns>
    public static bool IsBase64String(this string value)
    {
      // The quickest test. If the value is null or is equal to 0 it is not base64
      // Base64 string's length is always divisible by four, i.e. 8, 16, 20 etc.
      // If it is not you can return false. Quite effective
      // Further, if it meets the above criteria, then test for spaces.
      // If it contains spaces, it is not base64
      if (value.IsNullOrWhiteSpace() || value.Length % 4 != 0)
      {
        return false;
      }

      // 98% of all non base64 values are invalidated by this time.
      var index = value.Length - 1;

      // if there is padding step back
      if (value[index] == PaddingChar)
      {
        index--;
      }

      // if there are two padding chars step back a second time
      if (value[index] == PaddingChar)
      {
        index--;
      }

      // Now traverse over characters
      // You should note that I'm not creating any copy of the existing strings,
      // assuming that they may be quite large
      for (var i = 0; i <= index; i++)
      {
        // If any of the character is not from the allowed list
        if (Array.IndexOf(Base64Chars, value[i]) == -1)
        {
          return false;
        }
      }

      // If we got here, then the value is a valid base64 string
      return true;
    }

    /// <summary>
    /// Tests whether a string is a non-valid base64 string.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns>True if the string is not base64; otherwise false.</returns>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotBase64String(this string value) => !value.IsBase64String();
  }
}
