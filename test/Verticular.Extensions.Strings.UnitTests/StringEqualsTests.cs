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
  [TestCategory("StringExtensions/Equals")]
  public class StringEqualsTests
  {
    [TestMethod]
    public void EqualsAnyValidCollection()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeTrue("The match set contains the given value.");
    }

    [TestMethod]
    public void EqualsAnyValidCollectionCaseSensitivity()
    {
      // Arrange
      var value = "hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeFalse("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsAnyValidEmptyCollection()
    {
      // Arrange
      var value = "hello";
      var matchSet = EmptyArray.OfString();

      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeFalse("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsAnyValidList()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };

      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeTrue("The match set contains the given value.");
    }

    [TestMethod]
    public void EqualsAnyValidCollectionIgnoringCase()
    {
      // Arrange
      var value = "hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsAny(StringComparison.OrdinalIgnoreCase, matchSet);

      // Assert
      actual.Should().BeTrue("The match set contains the given value case-insensitively.");
    }

    [TestMethod]
    public void EqualsAnyValidListIgnoringCase()
    {
      // Arrange
      var value = "hello";
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };

      // Act
      var actual = value.EqualsAny(StringComparison.OrdinalIgnoreCase, matchSet);

      // Assert
      actual.Should().BeTrue("The match set contains the given value case-insensitively.");
    }

    [TestMethod]
    public void EqualsAnyNullValue()
    {
      // Arrange
      string value = null;
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };

      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsAnyNullMatchSet()
    {
      // Arrange
      var value = "Hello";
      var matchSet = (string[])null;

      // Act
      Action act = () => value.EqualsAny(matchSet);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsAnyValueUnknownComparison()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      Action act = () => value.EqualsAny((StringComparison)(-12), matchSet);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }


    [TestMethod]
    public void EqualsNoneValidCollection()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeFalse("The match set contains the given value.");
    }

    [TestMethod]
    public void EqualsNoneValidCollectionCaseSensitivity()
    {
      // Arrange
      var value = "hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeTrue("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsNoneValidEmptyCollection()
    {
      // Arrange
      var value = "hello";
      var matchSet = EmptyArray.OfString();

      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeTrue("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsNoneValidList()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };

      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeFalse("The match set contains the given value.");
    }

    [TestMethod]
    public void EqualsNoneValidCollectionIgnoringCase()
    {
      // Arrange
      var value = "hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      var actual = value.EqualsNone(StringComparison.OrdinalIgnoreCase, matchSet);

      // Assert
      actual.Should().BeFalse("The match set contains the given value case-insensitively.");
    }

    [TestMethod]
    public void EqualsNoneValidListIgnoringCase()
    {
      // Arrange
      var value = "hello";
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };

      // Act
      var actual = value.EqualsNone(StringComparison.OrdinalIgnoreCase, matchSet);

      // Assert
      actual.Should().BeFalse("The match set contains the given value case-insensitively.");
    }

    [TestMethod]
    public void EqualsNoneNullValue()
    {
      // Arrange
      string value = null;
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };


      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsNoneNullMatchSet()
    {
      // Arrange
      var value = "Hello";
      var matchSet = (string[])null;

      // Act
      Action act = () => value.EqualsNone(matchSet);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsNoneValueUnknownComparison()
    {
      // Arrange
      var value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };

      // Act
      Action act = () => value.EqualsNone((StringComparison)(-12), matchSet);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }
  }
}
