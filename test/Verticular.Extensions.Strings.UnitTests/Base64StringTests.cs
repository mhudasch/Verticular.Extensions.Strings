namespace Verticular.Extensions.Strings.UnitTests
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
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
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringEmptyTest()
    {
      // Arrange
      var base64 = string.Empty;

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringOnlyWhitespaceTest()
    {
      // Arrange
      var base64 = "   \t";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringWhitespaceTest()
    {
      // Arrange
      var base64 = "c29tZXRo    aW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringInvalidTest()
    {
      // Arrange
      var base64 = "INVALID";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringInvalidCharsTest()
    {
      // Arrange
      var base64 = "c29tZXRoaÄ5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsFalse(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringValidTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5n";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsTrue(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringValidOnePaddingCharTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsTrue(isBase64String);
    }

    [TestMethod]
    public void IsBase64StringValidTwoPaddingCharTest()
    {
      // Arrange
      var base64 = "c29tZXRoaW5nMA==";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      Assert.IsTrue(isBase64String);
    }
  }
}
