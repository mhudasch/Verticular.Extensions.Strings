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
  [TestCategory("StringExtensions")]
  public class StringExtensionsTests
  {
    [TestMethod]
    public void IsBase64StringNullTest()
    {
      // Arrange
      const string base64 = null;

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringEmptyTest()
    {
      // Arrange
      const string base64 = "";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringOnlyWhitespaceTest()
    {
      // Arrange
      const string base64 = "   \t";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringWhitespaceTest()
    {
      // Arrange
      const string base64 = "c29tZXRo    aW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringInvalidTest()
    {
      // Arrange
      const string base64 = "INVALID";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringInvalidCharsTest()
    {
      // Arrange
      const string base64 = "c29tZXRoaÄ5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeFalse("The string is not in valid base64 format.");
    }

    [TestMethod]
    public void IsBase64StringValidTest()
    {
      // Arrange
      const string base64 = "c29tZXRoaW5n";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }

    [TestMethod]
    public void IsBase64StringValidOnePaddingCharTest()
    {
      // Arrange
      const string base64 = "c29tZXRoaW5nMDA=";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }

    [TestMethod]
    public void IsBase64StringValidTwoPaddingCharTest()
    {
      // Arrange
      const string base64 = "c29tZXRoaW5nMA==";

      // Act
      var isBase64String = base64.IsBase64String();

      // Assert
      isBase64String.Should().BeTrue("The string is a valid base64 string.");
    }

    [TestMethod]
    public void EqualsAnyValidCollection()
    {
      // Arrange
      const string value = "Hello";
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
      const string value = "hello";
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
      const string value = "hello";
      var matchSet = new string[]
      {
      };


      // Act
      var actual = value.EqualsAny(matchSet);

      // Assert
      actual.Should().BeFalse("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsAnyValidList()
    {
      // Arrange
      const string value = "Hello";
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
      const string value = "hello";
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
      const string value = "hello";
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
      const string value = null;
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };


      // Act
      Action act = () => value.EqualsAny(matchSet);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsAnyNullMatchSet()
    {
      // Arrange
      const string value = "Hello";
      var matchSet = (string[])null;


      // Act
      Action act = () => value.EqualsAny(matchSet);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsAnyValueUnknownComparison()
    {
      // Arrange
      const string value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };


      // Act
      Action act = () => value.EqualsAny((StringComparison)(-12), matchSet);

      // Assert
      act.Should().Throw<ArgumentException>();
    }


    [TestMethod]
    public void EqualsNoneValidCollection()
    {
      // Arrange
      const string value = "Hello";
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
      const string value = "hello";
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
      const string value = "hello";
      var matchSet = new string[]
      {
      };


      // Act
      var actual = value.EqualsNone(matchSet);

      // Assert
      actual.Should().BeTrue("The match set does not contain the given value.");
    }

    [TestMethod]
    public void EqualsNoneValidList()
    {
      // Arrange
      const string value = "Hello";
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
      const string value = "hello";
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
      const string value = "hello";
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
      const string value = null;
      var matchSet = new List<string>
      {
        "Hello",
        "World"
      };


      // Act
      Action act = () => value.EqualsNone(matchSet);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsNoneNullMatchSet()
    {
      // Arrange
      const string value = "Hello";
      var matchSet = (string[])null;


      // Act
      Action act = () => value.EqualsNone(matchSet);

      // Assert
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void EqualsNoneValueUnknownComparison()
    {
      // Arrange
      const string value = "Hello";
      var matchSet = new[]
      {
        "Hello", "World"
      };


      // Act
      Action act = () => value.EqualsNone((StringComparison)(-12), matchSet);

      // Assert
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void IsNumericNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeFalse();
    }

    [TestMethod]
    public void IsNumericValidString()
    {
      // Arrange
      const string value = "000988024400";

      // Act
      var isNumeric = value.IsNumeric();

      // Assert
      isNumeric.Should().BeTrue();
    }

    [TestMethod]
    public void IsEmailAddressNullString()
    {
      // Arrange
      const string value = null;

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressEmptyString()
    {
      // Arrange
      const string value = "";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressWhiteSpaceString()
    {
      // Arrange
      const string value = "   \t\n";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressInvalidString()
    {
      // Arrange
      const string value = "h98802-44";

      // Act
      var isEmailAddress = value.IsEmailAddress();

      // Assert
      isEmailAddress.Should().BeFalse();
    }

    [TestMethod]
    public void IsEmailAddressValidString()
    {
      // Arrange
      const string value = "info@somewhere.de";

      // Act
      var isNumeric = value.IsEmailAddress();

      // Assert
      isNumeric.Should().BeTrue();
    }

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
    [DynamicData(nameof(StringExtensionsTests.WordCountTexts), DynamicDataSourceType.Method)]
    public void WordCountSimpleTextString(string value, int expectedWordCount)
    {
      // Arrange
      // see value parameter

      // Act
      var count = value.GetWordCount();

      // Assert
      count.Should().Be(expectedWordCount);
    }

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
      var containsAny = value.ContainsAll(CharacterComparer.CurrentCulture, search);

      // Assert
      containsAny.Should().BeTrue();
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
      var containsAny = value.ContainsAll(CharacterComparer.CurrentCultureIgnoreCase, search);

      // Assert
      containsAny.Should().BeTrue();
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
      var containsAny = value.ContainsAll(CharacterComparer.CurrentCulture, search);

      // Assert
      containsAny.Should().BeFalse();
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
      var containsAny = value.ContainsAll(CharacterComparer.CurrentCultureIgnoreCase, search);

      // Assert
      containsAny.Should().BeFalse();
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
