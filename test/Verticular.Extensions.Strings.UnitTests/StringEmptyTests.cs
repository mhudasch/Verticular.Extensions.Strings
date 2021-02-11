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
      const string value = null;

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceEmptyCheck()
    {
      // Arrange
      const string value = "";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceInvalidString()
    {
      // Arrange
      const string value = "  \tThis not a white space";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeFalse();
    }

    [TestMethod]
    public void IsOnlyWhiteSpaceValidString()
    {
      // Arrange
      const string value = "   \t  \r";

      // Act
      var isOnlyWhiteSpace = value.IsOnlyWhiteSpace();

      // Assert
      isOnlyWhiteSpace.Should().BeTrue();
    }
  }
}
