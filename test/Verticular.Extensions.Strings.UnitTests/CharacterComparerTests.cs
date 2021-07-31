namespace Verticular.Extensions.Strings.UnitTests
{
  using System;
  using System.Collections.Generic;
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

    [DataTestMethod]
    [DynamicData(nameof(CharacterComparerTests.AllComparers), DynamicDataSourceType.Method)]
    public void ExpectedCompare(CharacterComparer comparer)
    {
      // Arrange
      // see parameter

      // Act
      var bothObjectNullCompare = comparer.Compare((object)null, (object)null);
      var objectCompare = comparer.Compare((object)'h', (object)'h');
      var charCompare = comparer.Compare('h', 'h');
      var instance = 'h';
      var objectReferenceCompare = comparer.Compare((object)instance, (object)instance);
      var leftObjectNullCompare = comparer.Compare(null, (object)'h');
      var leftCharNullCompare = comparer.Compare(null, 'h');
      var rightObjectNullCompare = comparer.Compare((object)'h', null);
      var rightCharNullCompare = comparer.Compare('h', null);
      var lowerCompare = comparer.Compare('a', 'h');
      var higherCompoare = comparer.Compare('h', 'a');

      // Assert
      objectCompare.Should().Be(0);
      charCompare.Should().Be(0);
      bothObjectNullCompare.Should().Be(0);
      objectReferenceCompare.Should().Be(0);
      leftObjectNullCompare.Should().Be(-1);
      leftCharNullCompare.Should().Be(-1);
      rightObjectNullCompare.Should().Be(1);
      rightCharNullCompare.Should().Be(1);
      lowerCompare.Should().BeInRange(int.MinValue, -1);
      higherCompoare.Should().BeInRange(1, int.MaxValue);
    }

    [TestMethod]
    public void ExpectedEquality()
    {
      // Arrange
      var comparer = CharacterComparer.CurrentCulture;

      // Act
      var bothObjectNullEquality = comparer.Equals((object)null, (object)null);
      var bothCharNullEquality = comparer.Equals(null, null);
      var charEquality = comparer.Equals('h', 'h');
      var objectEquality = comparer.Equals((object)'h', (object)'h');

      var leftObjectNull = comparer.Equals((object)null, 'h');
      var leftCharNull = comparer.Equals(null, 'h');
      var rightObjectNull = comparer.Equals('h', (object)null);
      var rightCharNull = comparer.Equals('h', null);

      var numberObjectEquality = comparer.Equals(42, 42);
      var numberObjectInequaltiy = comparer.Equals(42, 84);
      var mixedLeftInequality = comparer.Equals('h', 84);
      var mixedRightInequality = comparer.Equals(42, 'h');

      // Assert
      bothObjectNullEquality.Should().BeTrue();
      bothCharNullEquality.Should().BeTrue();
      charEquality.Should().BeTrue();
      objectEquality.Should().BeTrue();

      leftObjectNull.Should().BeFalse();
      leftCharNull.Should().BeFalse();
      rightObjectNull.Should().BeFalse();
      rightCharNull.Should().BeFalse();

      numberObjectEquality.Should().BeTrue();
      numberObjectInequaltiy.Should().BeFalse();
      mixedLeftInequality.Should().BeFalse();
      mixedRightInequality.Should().BeFalse();
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

    [TestMethod]
    public void ComparerObjectHashCodeComparison()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);
      var obj = new object();

      // Act
      var objectHashCode = obj.GetHashCode();
      var comparerHashCode = comparer.GetHashCode(obj);

      // Assert
      comparer.Should().NotBeNull();
      objectHashCode.Should().Be(comparerHashCode);
    }

    [TestMethod]
    public void ComparerNonCharEqualityComparison()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);

      // Act
      var fromNumberCompare = 42.CompareTo(84);
      var comparerNumberCompare = comparer.Compare(42, 84);
      Action mixedCompareAct = () => comparer.Compare(42, 'A');
      Action mixedCompareAct2 = () => comparer.Compare('A', 42);
      Action objectCompareAct = () => comparer.Compare(new object(), 42);
      var nullCompare = comparer.Compare('A', null);

      // Assert
      comparer.Should().NotBeNull();
      fromNumberCompare.Should().Be(comparerNumberCompare);
      mixedCompareAct.Should().ThrowExactly<ArgumentException>();
      mixedCompareAct2.Should().ThrowExactly<ArgumentException>();
      objectCompareAct.Should().ThrowExactly<ArgumentException>();

      nullCompare.Should().Be(1);
    }

    [TestMethod]
    public void InvalidHasCodeArguments()
    {
      // Arrange
      var comparer = CharacterComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);

      // Act
      Action nullHashCodeAct = () => comparer.GetHashCode(null);
      Action nullHashCodeAct2 = () => comparer.GetHashCode((object)null);

      // Assert
      nullHashCodeAct.Should().ThrowExactly<ArgumentNullException>();
      nullHashCodeAct2.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void InvalidCreationArguments()
    {
      // Arrange

      // Act
      Action nullCreationArgumentAct = () => CharacterComparer.Create(null, ignoreCase: true);

      // Assert
      nullCreationArgumentAct.Should().ThrowExactly<ArgumentNullException>();
    }

    public static IEnumerable<object[]> AllComparers()
    {
      yield return new object[]
      {
        CharacterComparer.CurrentCulture
      };
      yield return new object[]
      {
        CharacterComparer.CurrentCultureIgnoreCase
      };
      yield return new object[]
      {
        CharacterComparer.InvariantCulture
      };
      yield return new object[]
      {
        CharacterComparer.InvariantCultureIgnoreCase
      };
    }
  }
}
