namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Contains")]
  public class StringContainsTests
  {
    [TestMethod]
    public void ContainsAnyNullString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      string value = null;

      // Act
      var containsAny = value.ContainsAny(search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAnyEmptyString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      var value = "";

      // Act
      var containsAny = value.ContainsAny(search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAnyNullCharacters()
    {
      // Arrange
      var search = (char[])null;
      var value = "Some text";

      // Act
      Action act = () => value.ContainsAny(search);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAnyEmptyCharacters()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";

      // Act
      var containsAny = value.ContainsAny(search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAnyInvalidComparer()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";
      var comparer = (CharacterComparison)42;

      // Act
      Action act = () => value.ContainsAny(comparer, search);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void ContainsAnyCharactersPositiveCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'B', 'e'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparison.CurrentCulture, search);

      // Assert
      containsAny.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsAnyCharactersPositiveIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'b', 'E'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsAny.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsAnyCharactersNegativeCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'b', 'E'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparison.CurrentCulture, search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAnyCharactersNegativeIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'x', 'X'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAllNullString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      string value = null;

      // Act
      var containsAll = value.ContainsAll(search);

      // Assert
      containsAll.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAllEmptyString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      var value = "";

      // Act
      var containsAll = value.ContainsAll(search);

      // Assert
      containsAll.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAllNullCharacters()
    {
      // Arrange
      var search = (char[])null;
      var value = "Some text";

      // Act
      Action act = () => value.ContainsAll(search);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAllInvalidComparer()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";
      var comparer = (CharacterComparison)42;

      // Act
      Action act = () => value.ContainsAll(comparer, search);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void ContainsAllEmptyCharacters()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";

      // Act
      var containsAll = value.ContainsAll(search);

      // Assert
      containsAll.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAllCharactersPositiveCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'f', 'e', 'a'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparison.CurrentCulture, search);

      // Assert
      containsAll.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsAllCharactersPositiveIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'F', 'e', 'A'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsAll.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsAllCharactersNegativeCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'f', 'e', 'a', 'x'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparison.CurrentCulture, search);

      // Assert
      containsAll.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAllCharactersNegativeIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'F', 'e', 'A', 'X'
      };
      var value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsAll.Should().BeFalse();
    }


    [TestMethod]
    public void ContainsNoneNullString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      string value = null;

      // Act
      var containsNone = value.ContainsNone(search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneEmptyString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      var value = "";

      // Act
      var containsNone = value.ContainsNone(search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneNullCharacters()
    {
      // Arrange
      var search = (char[])null;
      var value = "Some text";

      // Act
      Action act = () => value.ContainsNone(search);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsNoneEmptyCharacters()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";

      // Act
      var containsNone = value.ContainsNone(search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneInvalidComparer()
    {
      // Arrange
      var search = EmptyArray.OfChar();
      var value = "Some text";
      var comparer = (CharacterComparison)42;

      // Act
      Action act = () => value.ContainsNone(comparer, search);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void ContainsNoneCharactersPositiveCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'm', 'E'
      };
      var value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparison.CurrentCulture, search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneCharactersPositiveIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'x', 'B'
      };
      var value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneCharactersNegativeCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'M', 'e'
      };
      var value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparison.CurrentCulture, search);

      // Assert
      containsNone.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsNoneCharactersNegativeIgnoreCase()
    {
      // Arrange
      var search = new[]
      {
        'm', 'E'
      };
      var value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparison.CurrentCultureIgnoreCase, search);

      // Assert
      containsNone.Should().BeFalse();
    }
  }
}
