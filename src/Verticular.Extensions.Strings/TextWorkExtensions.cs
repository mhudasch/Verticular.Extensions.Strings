namespace Verticular.Extensions
{
  using System;

  /// <summary>
  /// Contains utility methods that extend the <see cref="string" /> type when working with large texts.
  /// </summary>
  public static class TextWorkExtensions
  {
    /// <summary>
    /// Gets the count of words in a text.
    /// </summary>
    /// <remarks>Counts everything except whitespaces as words and returns the count.</remarks>
    /// <param name="text">The text to count words in.</param>
    /// <returns>The count of words inside a text.</returns>
    public static int GetWordCount(this string? text)
    {
      var wordCount = 0;
      if (text.IsNullOrWhiteSpace())
      {
        return wordCount;
      }

      // implementation that avoids allocation
      var isInsideWordFlag = false;
      var wasInsideWordFlag = false;
      foreach (var c in text.AsSpan())
      {
        if (isInsideWordFlag)
        {
          wasInsideWordFlag = true;
        }

        if (char.IsWhiteSpace(c))
        {
          if (wasInsideWordFlag)
          {
            wordCount++;
            wasInsideWordFlag = false;
          }

          isInsideWordFlag = false;
        }
        else
        {
          isInsideWordFlag = true;
        }
      }

      if (wasInsideWordFlag)
      {
        wordCount++;
      }

      return wordCount;
    }
  }
}
