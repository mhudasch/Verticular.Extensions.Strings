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
    #endregion
    #region IsAlphaNumeric
    [TestMethod]
    public void IsAlphaNumericNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsAlphaNumericValidStringOnlyNumbers()
    {
      // Arrange
      const string value = "000988024400";

      // Act
      var isAlphaNumeric = value.IsAlphaNumeric();

      // Assert
      isAlphaNumeric.Should().BeTrue();
    }

    [TestMethod]
    public void IsAlphaNumericValidStringMixed()
    {
      // Arrange
      const string value = "000988ACCX024400";

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

    // Well why are there no more tests for different types of email types like hey.you@l-a-t.com
    // because we would only test the Argument/FormatException in the System.Net.Mail.MailAddress
    // at this point and that is not our code to test :)
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

    #endregion
    #region IsUri
    [TestMethod]
    public void IsUriNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeFalse();
    }

    [TestMethod]
    public void IsUriInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

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
      const string value = "http://www.google.de";

      // Act
      var isUri = value.IsUri();

      // Assert
      isUri.Should().BeTrue();
    }
    #endregion
  }
}
