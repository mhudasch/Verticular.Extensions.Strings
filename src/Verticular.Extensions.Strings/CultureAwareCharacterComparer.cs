namespace Verticular.Extensions
{
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

    public override int Compare(char x, char y) => this.ignoreCase ? this.textInfo.ToUpper(x).CompareTo(this.textInfo.ToUpper(y)) : x.CompareTo(y);

    public override bool Equals(char x, char y) => this.ignoreCase ? this.textInfo.ToUpper(x).Equals(this.textInfo.ToUpper(y)) : x.Equals(y);

    public override int GetHashCode(char obj) =>
      this.ignoreCase
        ? this.textInfo.ToUpper(obj).GetHashCode()
        : obj.GetHashCode();
  }
}
