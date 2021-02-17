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
      const string value = "HelloWorld";
      const char suffix = 'l';

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("He");
    }

    [TestMethod]
    public void UntilFirstCharCaseSensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'L';

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstCharCaseInsensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'L';

      // Act
      var until = value.Until(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("He");
    }

    [TestMethod]
    public void UntilFirstCharCaseInsensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'P';

      // Act
      var until = value.Until(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstStringCaseSensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "World";

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("Hello");
    }

    [TestMethod]
    public void UntilFirstStringCaseSensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "WORLD";

      // Act
      var until = value.Until(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilFirstStringCaseInsensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "wORlD";

      // Act
      var until = value.Until(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("Hello");
    }

    [TestMethod]
    public void UntilFirstStringCaseInsensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "NOT";

      // Act
      var until = value.Until(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastCharCaseSensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'o';

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloW");
    }

    [TestMethod]
    public void UntilLastCharCaseSensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'O';

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastCharCaseInsensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'O';

      // Act
      var until = value.UntilLast(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloW");
    }

    [TestMethod]
    public void UntilLastCharCaseInsensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'x';

      // Act
      var until = value.UntilLast(suffix, CharacterComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastStringCaseSensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "l";

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWor");
    }

    [TestMethod]
    public void UntilLastStringCaseSensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "LD";

      // Act
      var until = value.UntilLast(suffix);

      // Assert
      until.Should().Be("HelloWorld");
    }

    [TestMethod]
    public void UntilLastStringCaseInsensitive()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "L";

      // Act
      var until = value.UntilLast(suffix, StringComparison.CurrentCultureIgnoreCase);

      // Assert
      until.Should().Be("HelloWor");
    }

    [TestMethod]
    public void UntilLastStringCaseInsensitiveMismatch()
    {
      // Arrange
      const string value = "HelloWorld";
      const string suffix = "Not";

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
      const string suffix = "L";

      // Act
      Action act = () => value.Until(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilFirstStringNullMatch()
    {
      // Arrange
      const string value = "HelloWorld";
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
      const string value = "HelloWorld";
      const string suffix = "l";
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
      const char suffix = 'L';

      // Act
      Action act = () => value.Until(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilFirstCharInvalidComparison()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'l';
      const CharacterComparison comparison = (CharacterComparison)42;

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
      const string suffix = "L";

      // Act
      Action act = () => value.UntilLast(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilLastStringNullMatch()
    {
      // Arrange
      const string value = "HelloWorld";
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
      const string value = "HelloWorld";
      const string suffix = "l";
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
      const char suffix = 'L';

      // Act
      Action act = () => value.UntilLast(suffix);

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void UntilLastCharInvalidComparison()
    {
      // Arrange
      const string value = "HelloWorld";
      const char suffix = 'l';
      const CharacterComparison comparison = (CharacterComparison)42;

      // Act
      Action act = () => value.UntilLast(suffix, comparison);

      // Assert
      act.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public void CapitalizeEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("");
    }

    [TestMethod]
    public void CapitalizeOneLetterString()
    {
      // Arrange
      const string value = "a";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("A");
    }

    [TestMethod]
    public void CapitalizeLongerString()
    {
      // Arrange
      const string value = "this is small";

      // Act
      var capitalized = value.Capitalize();

      // Assert
      capitalized.Should().Be("This is small");
    }

    [TestMethod]
    public void CapitalizeNullString()
    {
      // Arrange
      const string value = (string)null;

      // Act
      Action act = () => value.Capitalize();

      // Assert
      act.Should().ThrowExactly<ArgumentNullException>();
    }
  }
}
