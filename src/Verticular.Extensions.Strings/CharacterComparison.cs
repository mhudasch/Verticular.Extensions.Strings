namespace Verticular.Extensions
{
  /// <summary>
  /// Specifies the culture and case rules to be used by certain overloads of
  /// the <see cref="char.CompareTo(char)"/> and <see cref="char.Equals(char)"/>
  /// methods.
  /// </summary>
  public enum CharacterComparison
  {
    /// <summary>
    /// Compare characters using the current culture.
    /// </summary>
    CurrentCulture = 0,

    /// <summary>
    /// Compare characters using the current culture, and
    /// ignoring the case of the characters being compared.
    /// </summary>
    CurrentCultureIgnoreCase = 1,

    /// <summary>
    /// Compare characters using the invariant culture.
    /// </summary>
    InvariantCulture = 2,
    
    /// <summary>
    /// 
    /// Compare strings using the invariant culture, and
    /// ignoring the case of the characters being compared.
    /// </summary>
    InvariantCultureIgnoreCase = 3,
  }
}
