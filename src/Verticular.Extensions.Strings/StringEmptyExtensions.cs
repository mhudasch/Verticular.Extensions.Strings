namespace Verticular.Extensions
{
  /// <summary>
  /// Wrapps static string apis into a uniform extension method api.
  /// </summary>
  public static class StringEmptyExtensions
  {
    /// <summary>
    /// Indicates whether the specified string is null or an empty string ("").
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>string.IsNullOrEmpty(value);</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

    /// <summary>
    /// Indicates whether the specified string neither null nor an empty string ("").
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is not null and not an empty string (""); otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>!string.IsNullOrEmpty(value);</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNullOrEmpty(this string? value) => !string.IsNullOrEmpty(value);

    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space
    /// characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is null or System.String.Empty, or if value consists
    /// exclusively of white-space characters.
    /// </returns>
    /// <remarks>
    /// This call is equivalent of <code>string.IsNullOrWhiteSpace(value);</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string? value) => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Indicates whether a specified string neither null, empty, nor consists only of white-space
    /// characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is not null, not System.String.Empty and if value does not consist
    /// exclusively of white-space characters.
    /// </returns>
    /// <remarks>
    /// This call is equivalent of <code>!string.IsNullOrWhiteSpace(value);</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNullOrWhiteSpace(this string? value) => !string.IsNullOrWhiteSpace(value);


    /// <summary>
    /// Indicates whether the specified string is null.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is null; otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>value is null;</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNull(this string? value) => value is null;

    /// <summary>
    /// Indicates whether the specified string is not null.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is not null; otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>!(value is null);</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNull(this string? value) => !(value is null);

    /// <summary>
    /// Indicates whether the specified string is an empty string ("").
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is an empty string (""); otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>!(value is null) &amp;&amp; value.Length == 0;</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty(this string? value) => !(value is null) && value.Length == 0;

    /// <summary>
    /// Indicates whether the specified string is not an empty string ("").
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is not an empty string (""); otherwise, false.</returns>
    /// <remarks>
    /// This call is equivalent of <code>!value.IsEmpty();</code>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEmpty(this string? value) => !value.IsEmpty();

    /// <summary>
    /// Indicates whether a specified string consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter consists exclusively of white-space characters.</returns>
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsOnlyWhiteSpace(this string? value)
    {
      // not null or empty - only white-space
      if (value is null || value.Length == 0)
      {
        return false;
      }

      for (var index = 0; index < value.Length; ++index)
      {
        if (!char.IsWhiteSpace(value[index]))
        {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Indicates whether a specified string does not consist only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter does not consist exclusively of white-space characters.</returns>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool IsNotOnlyWhiteSpace(this string? value) => !value.IsOnlyWhiteSpace();
  }
}
