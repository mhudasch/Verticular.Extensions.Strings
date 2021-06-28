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
    #region IsNumeric
    [TestMethod]
    public void IsNumericNullString()
    {
      // Arrange
      string value = null;

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericEmptyString()
    {
      // Arrange
      var value = "";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericWhiteSpaceString()
    {
      // Arrange
      var value = "   \t\n";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericInvalidString()
    {
      // Arrange
      var value = "h98802-44";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericValidString()
    {
      // Arrange
      var value = "000988024400";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeTrue();
    }
    #endregion
    #region IsAlphaNumeric
    [TestMethod]
    public void IsAlphaNumericNullString()
    {
      // Arrange
      string value = null;

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericEmptyString()
    {
      // Arrange
      var value = "";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericWhiteSpaceString()
    {
      // Arrange
      var value = "   \t\n";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericInvalidString()
    {
      // Arrange
      var value = "h98802-44";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericValidStringOnlyNumbers()
    {
      // Arrange
      var value = "000988024400";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeTrue();
    }

    [TestMethod]
    public void IsAlphaNumericValidStringMixed()
    {
      // Arrange
      var value = "000988ACCX024400";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeTrue();
    }
    #endregion
    #region IsEmailAddress

    [TestMethod]
    public void IsEmailAddressNullString()
    {
      // Arrange
      string value = null;

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressEmptyString()
    {
      // Arrange
      var value = "";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressWhiteSpaceString()
    {
      // Arrange
      var value = "   \t\n";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressInvalidString()
    {
      // Arrange
      var value = "h98802-44";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    // Well why are there no more tests for different types of email types like hey.you@l-a-t.com
    // because we would only test the Argument/FormatException in the System.Net.Mail.MailAddress
    // at this point and that is not our code to test :)
    [TestMethod]
    public void IsEmailAddressValidString()
    {
      // Arrange
      var value = "info@somewhere.de";

      // Act
      var isNumeric = value.IsEmailAddress();

      // Assert
      isNumeric.Should().BeTrue();
    }

    #endregion
    #region IsUri
    [TestMethod]
    public void IsUriNullString()
    {
      // Arrange
      string value = null;

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriEmptyString()
    {
      // Arrange
      var value = "";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriWhiteSpaceString()
    {
      // Arrange
      var value = "   \t\n";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriInvalidString()
    {
      // Arrange
      var value = "h98802-44";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    // Well why are there no more tests for different types of uri types like ftp:// file:/// etc?
    // because we would only test the UriFormatException at this point and that is not our code to test :)
    [TestMethod]
    public void IsUriValidString()
    {
      // Arrange
      var value = "http://www.google.de";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeTrue();
    }
    #endregion
  }
}
