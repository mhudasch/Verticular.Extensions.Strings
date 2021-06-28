namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/Substring")]
  public class SubstringTests
  {
    [TestMethod]
    public void UntilFirstCharCaseSensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'l';

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("He");
    }

    [TestMethod]
    public void UntilFirstCharCaseSensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'L';

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstCharCaseInsensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'L';

      // Act
      var until = value.Until(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("He");
    }

    [TestMethod]
    public void UntilFirstCharCaseInsensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'P';

      // Act
      var until = value.Until(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstStringCaseSensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "World";

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("Hello");
    }

    [TestMethod]
    public void UntilFirstStringCaseSensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "WORLD";

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstStringCaseInsensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "wORlD";

      // Act
      var until = value.Until(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("Hello");
    }

    [TestMethod]
    public void UntilFirstStringCaseInsensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "NOT";

      // Act
      var until = value.Until(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastCharCaseSensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'o';

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloW");
    }

    [TestMethod]
    public void UntilLastCharCaseSensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'O';

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastCharCaseInsensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'O';

      // Act
      var until = value.UntilLast(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloW");
    }

    [TestMethod]
    public void UntilLastCharCaseInsensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'x';

      // Act
      var until = value.UntilLast(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastStringCaseSensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "l";

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWor");
    }

    [TestMethod]
    public void UntilLastStringCaseSensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "LD";

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastStringCaseInsensitive()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "L";

      // Act
      var until = value.UntilLast(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWor");
    }

    [TestMethod]
    public void UntilLastStringCaseInsensitiveMismatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "Not";

      // Act
      var until = value.UntilLast(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstStringNullValue()
    {
      // Arrange
      var value = (string)null;
      var suffix = "L";

      // Act
      Action act = () => value.Until(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilFirstStringNullMatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = (string)null;

      // Act
      Action act = () => value.Until(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilFirstStringInvalidComparison()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "l";
      const StringComparison comparison = (StringComparison)42;

      // Act
      Action act = () => value.Until(suffix, comparison);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void UntilFirstCharNullValue()
    {
      // Arrange
      var value = (string)null;
      var suffix = 'L';

      // Act
      Action act = () => value.Until(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilFirstCharInvalidComparison()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'l';
      var comparison = (CharacterComparison)42;

      // Act
      Action act = () => value.Until(suffix, comparison);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void UntilLastStringNullValue()
    {
      // Arrange
      var value = (string)null;
      var suffix = "L";

      // Act
      Action act = () => value.UntilLast(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilLastStringNullMatch()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = (string)null;

      // Act
      Action act = () => value.UntilLast(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilLastStringInvalidComparison()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = "l";
      const StringComparison comparison = (StringComparison)42;

      // Act
      Action act = () => value.UntilLast(suffix, comparison);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void UntilLastCharNullValue()
    {
      // Arrange
      var value = (string)null;
      var suffix = 'L';

      // Act
      Action act = () => value.UntilLast(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilLastCharInvalidComparison()
    {
      // Arrange
      var value = "HelloWorld";
      var suffix = 'l';
      var comparison = (CharacterComparison)42;

      // Act
      Action act = () => value.UntilLast(suffix, comparison);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void CapitalizeEmptyString()
    {
      // Arrange
      var value = "";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("");
    }

    [TestMethod]
    public void CapitalizeOneLetterString()
    {
      // Arrange
      var value = "a";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("A");
    }

    [TestMethod]
    public void CapitalizeLongerString()
    {
      // Arrange
      var value = "this is small";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("This is small");
    }

    [TestMethod]
    public void CapitalizeNullString()
    {
      // Arrange
      var value = (string)null;

      // Act
      Action act = () => value.Capitalize();

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }
  }
}
