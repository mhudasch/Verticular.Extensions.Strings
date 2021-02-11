namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using System.Globalization;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Verticular.Extensions;

  [ExcludeFromCodeCoverage]
  [TestClass]
  [TestCategory("StringExtensions/CharacterComparer")]
  public class CharacterComparerTests
  {
    [TestMethod]
    public void EqualityInvariantCultureCaseInsensitive()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);

      // Act
      var objectEquality = comparer.Equals((object)'h', (object)'H');
      var charEquality = comparer.Equals('h', 'H');
      var objectInequality = comparer.Equals((object)'b', (object)'H');
      var charInequality = comparer.Equals('b', 'H');


      // Assert
      comparer.Should().NotBeNull();
      objectEquality.Should().BeTrue();
      charEquality.Should().BeTrue();
      objectInequality.Should().BeFalse();
      charInequality.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityInvariantCultureCaseSensitive()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: false);

      // Act
      var objectEquality = comparer.Equals((object)'H', (object)'H');
      var charEquality = comparer.Equals('H', 'H');
      var objectInequality = comparer.Equals((object)'h', (object)'H');
      var charInequality = comparer.Equals('h', 'H');

      // Assert
      comparer.Should().NotBeNull();
      objectEquality.Should().BeTrue();
      charEquality.Should().BeTrue();
      objectInequality.Should().BeFalse();
      charInequality.Should().BeFalse();
    }

    [TestMethod]
    public void HashCodeInvariantCultureCaseSensitive()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: false);

      // Act
      var objectHashCode = comparer.GetHashCode((object)'h');
      var objectHashCode2 = comparer.GetHashCode((object)'h');
      var objectHashCode3 = comparer.GetHashCode((object)'H');
      var charHashCode = comparer.GetHashCode('h');
      var charHashCode2 = comparer.GetHashCode('h');
      var charHashCode3 = comparer.GetHashCode('H');


      // Assert
      comparer.Should().NotBeNull();
      objectHashCode.Should().Be(objectHashCode2);
      objectHashCode.Should().NotBe(objectHashCode3);
      charHashCode.Should().Be(charHashCode2);
      charHashCode.Should().NotBe(charHashCode3);

      objectHashCode.Should().Be(charHashCode);
      objectHashCode2.Should().Be(charHashCode2);
      objectHashCode3.Should().Be(charHashCode3);
      objectHashCode.Should().Be(charHashCode2);

      objectHashCode.Should().NotBe(charHashCode3);
      objectHashCode3.Should().NotBe(charHashCode);
    }

    [TestMethod]
    public void HashCodeInvariantCultureCaseInsensitive()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);

      // Act
      var objectHashCode = comparer.GetHashCode((object)'h');
      var objectHashCode2 = comparer.GetHashCode((object)'h');
      var objectHashCode3 = comparer.GetHashCode((object)'H');
      var charHashCode = comparer.GetHashCode('h');
      var charHashCode2 = comparer.GetHashCode('h');
      var charHashCode3 = comparer.GetHashCode('H');


      // Assert
      comparer.Should().NotBeNull();
      objectHashCode.Should().Be(objectHashCode2);
      objectHashCode.Should().Be(objectHashCode3);
      charHashCode.Should().Be(charHashCode2);
      charHashCode.Should().Be(charHashCode3);

      objectHashCode.Should().Be(charHashCode);
      objectHashCode2.Should().Be(charHashCode2);
      objectHashCode3.Should().Be(charHashCode3);
      objectHashCode.Should().Be(charHashCode2);

      objectHashCode.Should().Be(charHashCode3);
      objectHashCode3.Should().Be(charHashCode);
    }


  }
}
