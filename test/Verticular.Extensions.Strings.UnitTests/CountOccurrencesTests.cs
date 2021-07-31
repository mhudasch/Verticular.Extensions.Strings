namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/CountOccurrences")]
  public class CountOccurrencesTests
  {
    [TestMethod]
    public void CountOccurrencesStringInNullString()
    {
      // Arrange
      var search = "hey";
      string value = null;

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesStringInEmptyString()
    {
      // Arrange
      var search = "hey";
      var value = "";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesOfNullString()
    {
      // Arrange
      string search = null;
      var value = "helloWorld";

      // Act
      Action act = () => value.CountOccurrences(search);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void CountOccurrencesOfEmptyString()
    {
      // Arrange
      var search = string.Empty;
      var value = "helloWorld";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesOfStringCaseSensitiveSuccess()
    {
      // Arrange
      var search = "subfolder";
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(3);
    }

    [TestMethod]
    public void CountOccurrencesOfStringCaseSensitiveFailed()
    {
      // Arrange
      var search = "subFolder";
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesOfStringCaseInsensitiveSuccess()
    {
      // Arrange
      var search = "SuBfOlDeR";
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      occurrences.Should().Be(3);
    }

    [TestMethod]
    public void CountOccurrencesOfStringCaseInsensitiveFailed()
    {
      // Arrange
      var search = "XXX";
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesCharInNullString()
    {
      // Arrange
      var search = 't';
      string value = null;

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesCharInEmptyString()
    {
      // Arrange
      var search = 't';
      var value = "";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesOfCharCaseSensitiveSuccess()
    {
      // Arrange
      var search = 'f';
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(5);
    }

    [TestMethod]
    public void CountOccurrencesOfCharCaseSensitiveFailed()
    {
      // Arrange
      var search = 'z';
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search);

      // Assert
      occurrences.Should().Be(0);
    }

    [TestMethod]
    public void CountOccurrencesOfCharCaseInsensitiveSuccess()
    {
      // Arrange
      var search = 'T';
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      occurrences.Should().Be(2);
    }

    [TestMethod]
    public void CountOccurrencesOfCharCaseInsensitiveFailed()
    {
      // Arrange
      var search = 'z';
      var value = "/folder/subfolder/subfolder/subfolder/file.txt";

      // Act
      var occurrences = value.CountOccurrences(search, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      occurrences.Should().Be(0);
    }
  }
}
