namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Empty")]
  public class StringEmptyTests
  {
    [TestMethod]
    public void IsOnlyWhiteSpaceNullCheck()
    {
      // Arrange
      string value = null;

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceEmptyCheck()
    {
      // Arrange
      var value = "";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceInvalidString()
    {
      // Arrange
      var value = "  \tThis not a white space";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceValidString()
    {
      // Arrange
      var value = "   \t  \r";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeTrue();
    }
  }
}
