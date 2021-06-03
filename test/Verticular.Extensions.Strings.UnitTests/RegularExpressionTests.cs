namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using System.Text.RegularExpressions;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/RegEx")]
  public class RegularExpressionTests
  {
    [TestMethod]
    public void IsMatchOfNullString()
    {
      // Arrange
      var pattern = @"\d+";
      const string value = null;

      // Act
      var isMatch = value.IsMatch(pattern);

      // Assert
      isMatch.Should().BeFalse();
    }

    [TestMethod]
    public void IsMatchOfEmptyString()
    {
      // Arrange
      var pattern = @"\d+";
      const string value = "";

      // Act
      var isMatch = value.IsMatch(pattern);

      // Assert
      isMatch.Should().BeFalse();
    }

    [TestMethod]
    public void IsMatchingNullPattern()
    {
      // Arrange
      var pattern = (string)null;
      const string value = "";

      // Act
      Action act = () => value.IsMatch(pattern);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void IsMatchingInvalidPattern()
    {
      // Arrange
      var pattern = @"\xT";
      const string value = "";

      // Act
      Action act = () => value.IsMatch(pattern);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void IsMatchOfSensitivePattern()
    {
      // Arrange
      var pattern = @"^Hello$";
      const string value = "Hello";

      // Act
      var isMatch = value.IsMatch(pattern);

      // Assert
      isMatch.Should().BeTrue();
    }

    [TestMethod]
    public void IsMatchOfInsensitivePattern()
    {
      // Arrange
      var pattern = @"^Hello$";
      const string value = "HeLLo";

      // Act
      var isMatch = value.IsMatch(pattern, RegexOptions.IgnoreCase);

      // Assert
      isMatch.Should().BeTrue();
    }


    [TestMethod]
    public void IsMatchOfEmbeddInsensitivePattern()
    {
      // Arrange
      var pattern = @"(?i)^Hello$";
      const string value = "HeLLo";

      // Act
      var isMatch = value.IsMatch(pattern);

      // Assert
      isMatch.Should().BeTrue();
    }
  }
}
