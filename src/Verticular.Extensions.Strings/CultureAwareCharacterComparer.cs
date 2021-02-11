namespace Verticular.Extensions
{
  using System;
  using System.Globalization;

  internal sealed class CultureAwareCharacterComparer : CharacterComparer
  {
    private readonly bool ignoreCase;
    private readonly TextInfo textInfo;

    public CultureAwareCharacterComparer(CultureInfo culture, bool ignoreCase)
    {
      this.textInfo = culture.TextInfo;
      this.ignoreCase = ignoreCase;
    }

    public override int Compare(char? x, char? y)
    {
      if (x == y)
      {
        return 0;
      }

      if (x is null)
      {
        return -1;
      }
      var xValue = x.Value;

      if (y is null)
      {
        return 1;
      }
      var yValue = y.Value;
      return this.ignoreCase ? this.textInfo.ToUpper(xValue).CompareTo(this.textInfo.ToUpper(yValue)) : xValue.CompareTo(yValue);
    }

    public override bool Equals(char? x, char? y)
    {
      if (x == y)
      {
        return true;
      }

      if (x is null || y is null)
      {
        return false;
      }
      var xValue = x.Value;
      var yValue = y.Value;
      return this.ignoreCase ? this.textInfo.ToUpper(xValue).Equals(this.textInfo.ToUpper(yValue)) : xValue.Equals(yValue);
    }

    public override int GetHashCode(char? obj)
    {
      if (obj is null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      return this.ignoreCase
        ? this.textInfo.ToUpper(obj.Value).GetHashCode()
        : obj.GetHashCode();
    }
  }
}
