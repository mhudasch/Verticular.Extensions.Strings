namespace Verticular.Extensions.Strings.UnitTests
{
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Match")]
  public class StringMatchTests
  {
    [TestMethod]
    public void IsNumericNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericValidString()
    {
      // Arrange
      const string value = "000988024400";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeTrue();
    }

    [TestMethod]
    public void IsEmailAddressNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressValidString()
    {
      // Arrange
      const string value = "info@somewhere.de";

      // Act
      var isNumeric = value.IsEmailAddress();

      // Assert
      isNumeric.Should().BeTrue();
    }
  }
}
