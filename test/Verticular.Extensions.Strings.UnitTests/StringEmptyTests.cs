namespace Verticular.Extensions.Strings.UnitTests
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class StringEmptyTests
  {
    [TestMethod]
    public void EmptyWhiteSpaceTest()
    {
      // Arrange
      string whiteSpaces = "";

      // Act
      var isWhiteSpace = whiteSpaces.IsOnlyWhiteSpace();

      // Assert
      Assert.IsFalse(isWhiteSpace);
    }

    [TestMethod]
    public void NullWhiteSpaceTest()
    {
      // Arrange
      string whiteSpaces = null;

      // Act
      var isWhiteSpace = whiteSpaces.IsOnlyWhiteSpace();

      // Assert
      Assert.IsFalse(isWhiteSpace);
    }

    [TestMethod]
    public void NoWhiteSpaceTest()
    {
      // Arrange
      string whiteSpaces = " ..ABBA..  ";

      // Act
      var isWhiteSpace = whiteSpaces.IsOnlyWhiteSpace();

      // Assert
      Assert.IsFalse(isWhiteSpace);
    }

    [TestMethod]
    public void OnlyWhiteSpaceTest()
    {
      // Arrange
      string whiteSpaces = " \t\r\n  ";

      // Act
      var isWhiteSpace = whiteSpaces.IsOnlyWhiteSpace();

      // Assert
      Assert.IsTrue(isWhiteSpace);
    }
  }
}