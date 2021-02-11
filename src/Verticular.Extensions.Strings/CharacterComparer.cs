namespace Verticular.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Globalization;

  /// <summary>
  /// Represents a character comparison operation that uses specific case and culture-based comparison rules.
  /// </summary>
  [Serializable]
  public abstract class CharacterComparer : IComparer, IEqualityComparer, IComparer<char?>, IEqualityComparer<char?>
  {
    /// <summary>
    /// Gets a <see cref="CharacterComparer" /> object that performs a case-sensitive character comparison using the comparison rules of the invariant culture.
    /// </summary>
    /// <returns>A new <see cref="CharacterComparer" /> object.</returns>
    public static CharacterComparer InvariantCulture { get; } = new CultureAwareCharacterComparer(CultureInfo.InvariantCulture, false);

    /// <summary>
    /// Gets a <see cref="CharacterComparer" /> object that performs a case-insensitive character comparison using the comparison rules of the invariant culture.
    /// </summary>
    /// <returns>A new <see cref="CharacterComparer" /> object.</returns>
    public static CharacterComparer InvariantCultureIgnoreCase { get; } = new CultureAwareCharacterComparer(CultureInfo.InvariantCulture, true);

    /// <summary>
    /// Gets a <see cref="CharacterComparer" /> object that performs a case-sensitive character comparison using the comparison rules of the current culture.
    /// </summary>
    /// <returns>A new <see cref="CharacterComparer" /> object.</returns>
    public static CharacterComparer CurrentCulture => new CultureAwareCharacterComparer(CultureInfo.CurrentCulture, false);

    /// <summary>
    /// Gets a <see cref="CharacterComparer" /> object that performs case-insensitive character comparisons using the comparison rules of the current culture.
    /// </summary>
    /// <returns>A new object for string comparison.</returns>
    public static CharacterComparer CurrentCultureIgnoreCase => new CultureAwareCharacterComparer(CultureInfo.CurrentCulture, true);

    /// <summary>
    /// Creates a <see cref="CharacterComparer" /> object that compares characters according to the rules of a specified culture.
    /// </summary>
    /// <param name="culture">
    /// A culture whose linguistic rules are used to perform a character comparison.
    /// </param>
    /// <param name="ignoreCase">
    /// <see langword="true" /> to specify that comparison operations be case-insensitive; <see langword="false" /> 
    /// to specify that comparison operations be case-sensitive.</param>
    /// <returns>A new <see cref="CharacterComparer" /> object that performs character comparisons according to the comparison rules used by the <paramref name="culture" /> parameter and the case rule specified by the <paramref name="ignoreCase" /> parameter.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="culture" /> is <see langword="null" />.</exception>
    public static CharacterComparer Create(CultureInfo? culture, bool ignoreCase)
    {
      if (culture is null)
      {
        throw new ArgumentNullException(nameof(culture));
      }

      return new CultureAwareCharacterComparer(culture, ignoreCase);
    }

    /// <inheritdoc/>
    public abstract bool Equals(char? x, char? y);

    /// <inheritdoc/>
    public abstract int GetHashCode(char? obj);

    /// <inheritdoc/>
    public abstract int Compare(char? x, char? y);

    /// <inheritdoc/>
    public new bool Equals(object x, object y)
    {
      if (x == y)
      {
        return true;
      }

      if (x == null || y == null)
      {
        return false;
      }

      return x is char x1 && y is char y1 ? this.Equals(x1, y1) : x.Equals(y);
    }

    /// <inheritdoc/>
    public int GetHashCode(object obj)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      return obj is char ch ? this.GetHashCode(ch) : obj.GetHashCode();
    }

    /// <inheritdoc/>
    public int Compare(object x, object y)
    {
      if (x == y)
      {
        return 0;
      }

      if (x is null)
      {
        return -1;
      }

      if (y is null)
      {
        return 1;
      }

      switch (x)
      {
        case char x1 when y is char y1:
          return this.Compare(x1, y1);
        case IComparable comparable:
          return comparable.CompareTo(y);
        default:
          throw new ArgumentException("At least one object must implement IComparable.");
      }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="CharacterComparer"/> class.
    /// </summary>
    protected CharacterComparer() { }

    internal static CharacterComparer FromComparison(CharacterComparison comparisonType) => comparisonType switch
    {
      CharacterComparison.CurrentCulture => CharacterComparer.CurrentCulture,
      CharacterComparison.CurrentCultureIgnoreCase => CharacterComparer.CurrentCultureIgnoreCase,
      CharacterComparison.InvariantCulture => CharacterComparer.InvariantCulture,
      CharacterComparison.InvariantCultureIgnoreCase => CharacterComparer.InvariantCultureIgnoreCase,
      _ => throw new ArgumentException($"The given comparison type '{comparisonType}' is no valid value."),
    };
  }
}
