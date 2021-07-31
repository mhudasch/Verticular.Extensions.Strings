namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Remove")]
  public class StringRemovalTests
  {
    [TestMethod]
    public void RemoveCharactersFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        'a', 'i', 'L'
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("orem psum dolor st met, consetetur sdpscng eltr, sed dm nonumy", "because 'a', 'i' and 'L' have been removed");
    }

    [TestMethod]
    public void RemoveCharactersCaseInsensitiveFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        'a', 'i', 'L'
      };

      // Act
      var actual = value.Remove(CharacterComparison.CurrentCultureIgnoreCase, itemsToRemove);

      // Assert
      actual.Should().Be("orem psum door st met, consetetur sdpscng etr, sed dm nonumy",
        "because 'a', 'i' and 'L' have been removed ignoring casing");
    }

    [TestMethod]
    public void RemoveNoCharactersFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = EmptyArray.OfChar();

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy",
        "because no characters have been removed");
    }

    [TestMethod]
    public void RemoveNullCharactersFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      char[] itemsToRemove = null;

      // Act
      var act = new Action(() => value.Remove(itemsToRemove));

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>("because the character array is null");
    }

    [TestMethod]
    public void RemoveCharactersFromNullString()
    {
      // Arrange
      string value = null;
      var itemsToRemove = new char[]
      {
        'a', 'i', 'L'
      };

      // Act
      var act = new Action(() => value.Remove(itemsToRemove));

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>("because the source value is null");
    }

    [TestMethod]
    public void RemoveCharactersFromEmptyString()
    {
      // Arrange
      var value = string.Empty;
      var itemsToRemove = new char[]
      {
        'a', 'i', 'L'
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().BeEmpty("because it was empty to begin with");
    }

    [TestMethod]
    public void RemoveStringsFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        "ipsum ", " elitr", "SIT ", "ipsum "
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("Lorem dolor sit amet, consetetur sadipscing, sed diam nonumy", "because sub strings have been removed");
    }

    [TestMethod]
    public void RemoveStringsCaseInsensitiveFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        "ipsum ", " elitr", "SIT "
      };

      // Act
      var actual = value.Remove(StringComparison.CurrentCultureIgnoreCase, itemsToRemove);

      // Assert
      actual.Should().Be("Lorem dolor amet, consetetur sadipscing, sed diam nonumy",
        "because sub strings have been removed ignoring casing");
    }

    [TestMethod]
    public void RemoveNoStringsFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = EmptyArray.OfString();

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy",
        "because no strings have been removed");
    }

    [TestMethod]
    public void RemoveNullStringsFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      string[] itemsToRemove = null;

      // Act
      var act = new Action(() => value.Remove(itemsToRemove));

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>("because the string array is null");
    }

    [TestMethod]
    public void RemoveStringsFromNullString()
    {
      // Arrange
      string value = null;
      var itemsToRemove = new[]
      {
        "ipsum ", " elitr", "SIT "
      };

      // Act
      var act = new Action(() => value.Remove(itemsToRemove));

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>("because the source value is null");
    }

    [TestMethod]
    public void RemoveStringsFromEmptyString()
    {
      // Arrange
      var value = string.Empty;
      var itemsToRemove = new[]
      {
        "ipsum ", " elitr", "SIT "
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().BeEmpty("because it was empty to begin with");
    }

    [TestMethod]
    public void RemoveNotFoundStringsFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        "XXX", "YY", "ZZ"
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy",
        "because strings to remove are not present in the source string");
    }

    [TestMethod]
    public void RemoveCompoundStringsFromLoremString()
    {
      // Arrange
      var value = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy";
      var itemsToRemove = new[]
      {
        " con", "setet", "etur ", "ame", "amet,"
      };

      // Act
      var actual = value.Remove(itemsToRemove);

      // Assert
      actual.Should().Be("Lorem ipsum dolor sit sadipscing elitr, sed diam nonumy",
        "because sub strings have been removed");
    }
  }
}
