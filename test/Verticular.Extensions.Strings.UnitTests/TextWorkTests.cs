namespace Verticular.Extensions.Strings.UnitTests
{
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/TextWork")]
  public class TextWorkTests
  {
    [TestMethod]
    public void WordCountNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var count = value.GetWordCount();

      // Assert
      count.Should().Be(0);
    }

    [TestMethod]
    public void WordCountEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var count = value.GetWordCount();

      // Assert
      count.Should().Be(0);
    }

    [TestMethod]
    public void WordCountWhiteSpaceString()
    {
      // Arrange
      const string value = "  \t\n";

      // Act
      var count = value.GetWordCount();

      // Assert
      count.Should().Be(0);
    }

    [DataTestMethod]
    [DynamicData(nameof(TextWorkTests.WordCountTexts), DynamicDataSourceType.Method)]
    public void WordCountSimpleTextString(string value, int expectedWordCount)
    {
      // Arrange
      // see value parameter

      // Act
      var count = value.GetWordCount();

      // Assert
      count.Should().Be(expectedWordCount);
    }

    public static IEnumerable<object[]> WordCountTexts()
    {
      yield return new object[]
      {
        "Hello world", 2
      };
      yield return new object[]
      {
        "       Hello world", 2
      };
      yield return new object[]
      {
        "Hello world       ", 2
      };
      yield return new object[]
      {
        "       Hello      world       ", 2
      };
      yield return new object[]
      {
        "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
        100
      };
      yield return new object[]
      {
        @"
This is some headline
1. first 
2. second
3. third
",
        10
      };
    }
  }
}
