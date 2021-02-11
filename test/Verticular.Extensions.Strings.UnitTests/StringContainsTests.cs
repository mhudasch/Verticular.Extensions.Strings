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
  public class StringContaintsTests
  {
    [TestMethod]
    public void ContainsAnyNullString()
    {
      // Arrange
      var search = new[]
      {
        'e', 'B'
      };
      const string value = null;

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
      const string value = "";

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
      const string value = "Some text";

      // Act
      Action act = () => value.ContainsAny(search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAnyEmptyCharacters()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";

      // Act
      var containsAny = value.ContainsAny(search);

      // Assert
      containsAny.Should().BeFalse();
    }

    [TestMethod]
    public void ContainsAnyNullComparer()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";
      var comparer = (CharacterComparer)null;

      // Act
      Action act = () => value.ContainsAny(comparer, search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAnyCharactersPositiveCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'B', 'e'
      };
      const string value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparer.CurrentCultureIgnoreCase, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAny = value.ContainsAny(CharacterComparer.CurrentCultureIgnoreCase, search);

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
      const string value = null;

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
      const string value = "";

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
      const string value = "Some text";

      // Act
      Action act = () => value.ContainsAll(search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAllNullComparer()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";
      var comparer = (CharacterComparer)null;

      // Act
      Action act = () => value.ContainsAll(comparer, search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsAllEmptyCharacters()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";

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
      const string value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparer.CurrentCultureIgnoreCase, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsAll = value.ContainsAll(CharacterComparer.CurrentCultureIgnoreCase, search);

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
      const string value = null;

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
      const string value = "";

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
      const string value = "Some text";

      // Act
      Action act = () => value.ContainsNone(search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsNoneEmptyCharacters()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";

      // Act
      var containsNone = value.ContainsNone(search);

      // Assert
      containsNone.Should().BeTrue();
    }

    [TestMethod]
    public void ContainsNoneNullComparer()
    {
      // Arrange
      var search = new char[]
      {
      };
      const string value = "Some text";
      var comparer = (CharacterComparer)null;

      // Act
      Action act = () => value.ContainsNone(comparer, search);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ContainsNoneCharactersPositiveCaseSensitive()
    {
      // Arrange
      var search = new[]
      {
        'm', 'E'
      };
      const string value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparer.CurrentCultureIgnoreCase, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparer.CurrentCulture, search);

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
      const string value = "My cat eats fish.";

      // Act
      var containsNone = value.ContainsNone(CharacterComparer.CurrentCultureIgnoreCase, search);

      // Assert
      containsNone.Should().BeFalse();
    }
  }
}
