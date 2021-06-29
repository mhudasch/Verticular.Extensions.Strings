namespace Verticular.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// 
  /// </summary>
  public static class StringRemoveExtensions
  {
    public static string Remove(this string? value, params char[] characters) =>
      value.Remove(CharacterComparison.CurrentCulture, characters);

    public static string Remove(this string? value, CharacterComparison comparisonType, params char[] characters)
    {
      if (value is null || value.Length == 0)
      {
        throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
      }

      if (characters is null)
      {
        throw new ArgumentNullException(nameof(characters));
      }

      if (characters.Length == 0)
      {
        return value;
      }

      var comparer = CharacterComparer.FromComparison(comparisonType);
      // only use one allocation maximum of string value length
      // which will be shorter when matches were found; otherwise a copy of the input value
      var targetCharacters = new char[value.Length];
      var targetCharactersIndex = 0;
      // this would be maximum of O(value.Length*characters.Length)
      // this is faster than replace with empty string because of fewer allocations
      // and is faster than a indexof -> remove combination because of fewer calls and allocations
      for (var i = 0; i < value.Length; ++i)
      {
        foreach (var c in characters)
        {
          if (comparer.Compare(c, value[i]) != 0)
          {
            targetCharacters[targetCharactersIndex++] = value[i];
          }
          // else just skip the matching character
        }
      }

      return new string(targetCharacters, 0, targetCharactersIndex);
    }

    public static string Remove(this string? value, params string[] strings) =>
      value.Remove(StringComparison.CurrentCulture, strings);

    public static string Remove(this string? value, StringComparison comparisonType, params string[] strings)
    {
      if (value is null || value.Length == 0)
      {
        throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
      }

      if (strings is null)
      {
        throw new ArgumentNullException(nameof(strings));
      }

      if (strings.Length == 0)
      {
        return value;
      }

      // use this to manage duplicates on add
      var uniqueSlices = new HashSet<ulong>(EqualityComparer<ulong>.Default);
      foreach (var s in strings)
      {
        var sliceIndex = 0;
        while ((sliceIndex = value.IndexOf(s, sliceIndex, comparisonType)) > -1)
        {
          // normally I would like to use tuple<int,int> but that is not downwards compatible enough
          var slice = ((ulong)(uint)sliceIndex << Shift) | (uint)s.Length;
          uniqueSlices.Add(slice);
        }
      }

      // nothing found in the value string
      if (uniqueSlices.Count == 0)
      {
        return value;
      }

      // first sort all found slices
      // -> loops over all slices the first time
      var sortedSlices = uniqueSlices.ToArray();
      Array.Sort(sortedSlices, new SliceComparer());

      // now detect and merge overlapping slices
      // this also puts them in reverse order so remove is simpler
      // -> loops over all slices the second time but should minimize amount of slices
      var cleanSlices = new Stack<ulong>();
      cleanSlices.Push(sortedSlices[0]);
      for (var i = 0; i < sortedSlices.Length; ++i)
      {
        var top = cleanSlices.Peek();

        var currentStart = (int)(uint)(sortedSlices[i] >> Shift);
        var currentEnd = currentStart + (int)(uint)(sortedSlices[i] & uint.MaxValue);
        var topStart = (int)(uint)(top >> Shift);
        var topEnd = topStart + (int)(uint)(top & uint.MaxValue);

        if (topEnd < currentStart)
        {
          cleanSlices.Push(sortedSlices[i]);
        }
        else if (topEnd < currentEnd)
        {
          topEnd = currentEnd;
          cleanSlices.Pop();
          cleanSlices.Push(((ulong)(uint)topStart << Shift) | (uint)(topEnd - topStart));
        }
      }

      // remove all unique slices from end to start of the string
      // that way we do not have to realign all the slice starting indices
      // -> loops over all slices the third time now that all unique slices are known
      var sb = new StringBuilder(value);
      foreach (var sl in cleanSlices)
      {
        var sliceIndex = (int)(uint)(sl >> Shift);
        var sliceSize = (int)(uint)(sl & uint.MaxValue);
        sb = sb.Remove(sliceIndex, sliceSize);
      }

      // use string builder to avoid string allocation to the very end
      return sb.ToString();
    }

    private const int Shift = 32;

    internal class SliceComparer : IComparer
    {
      public int Compare(object x, object y)
      {
        var first = (ulong)x;
        var second = (ulong)y;

        var firstStart = (int)(uint)(first >> Shift);
        var firstEnd = firstStart + (int)(uint)(first & uint.MaxValue);

        var secondStart = (int)(uint)(second >> Shift);
        var secondEnd = secondStart + (int)(uint)(second & uint.MaxValue);

        if (firstStart == secondStart)
        {
          return firstEnd - secondEnd;
        }
        return firstStart - secondStart;
      }
    }
  }
}
