namespace Verticular.Extensions.Strings.UnitTests
{
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Base64")]
  public class Base64StringTests
  {
    [TestMethod]
    public void IsBase64StringNullTest()
    {
      // Arrange
      string base64 = null;

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringEmptyTest()
    {
      // Arrange
      var base64 = "";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringOnlyWhitespaceTest()
    {
      // Arrange
      var base64 = "   \t";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringWhitespaceTest()
    {
      // Arrange
      var base64 = "c29tZXRo    aW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringInvalidTest()
    {
      // Arrange
      var base64 = "INVALID";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringInvalidCharsTest()
    {
      // Arrange
      var base64 = "c29tZXRoaÄ5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringValidTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5n";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }

    [TestMethod]
    public void IsBase64StringValidOnePaddingCharTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }

    [TestMethod]
    public void IsBase64StringValidTwoPaddingCharTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5nMA==";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }
  }
}
