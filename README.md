# Verticular String Extensions

This repository contains the dotnet [String](https://docs.microsoft.com/de-de/dotnet/api/system.string) Extension methods that you were missing all those years.

[![Build Status](https://martinhudasch.visualstudio.com/verticular.extensions.strings/_apis/build/status/mhudasch.verticular.extensions.strings)](https://martinhudasch.visualstudio.com/verticular.extensions.strings/_build/latest?definitionId=4)

[![SonarMaintain](https://sonarcloud.io/api/project_badges/measure?project=mhudasch_verticular.extensions.strings&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=mhudasch_verticular.extensions.strings)
[![SonarRely](https://sonarcloud.io/api/project_badges/measure?project=mhudasch_verticular.extensions.strings&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=mhudasch_verticular.extensions.strings)
[![SonarSec](https://sonarcloud.io/api/project_badges/measure?project=mhudasch_verticular.extensions.strings&metric=security_rating)](https://sonarcloud.io/dashboard?id=mhudasch_verticular.extensions.strings)

[![SonarLOC](https://sonarcloud.io/api/project_badges/measure?project=mhudasch_verticular.extensions.strings&metric=ncloc)](https://sonarcloud.io/dashboard?id=mhudasch_verticular.extensions.strings)

<!-- [![NuGet Badge](https://buildstats.info/nuget/verticular.extensions.strings)](https://www.nuget.org/packages/verticular.extensions.strings/) -->

## Code Samples

### Null, Empty and WhiteSpace

To prevent the use of the static string methods to check for null or empty it is easier to call the extension method directly on the string itself.

```cs
if(myString.IsNullOrEmpty())
{
  // some code
}
```

Another case is when using the methods to check for null or empty in a negated form the negation (the `!`)often gets overlooked. So we have an explicit method for this as well.

```cs
if(myString.IsNotNullOrEmpty())
{
  // some code
}
```

To round the package up nicely there are methods for all other facets around this checks like:

```cs
myString.IsNull()
myString.IsNotNull()

myString.IsEmpty()
myString.IsNotEmpty()

myString.IsOnlyWhiteSpace()
myString.IsNotOnlyWhiteSpace()

myString.IsNullOrWhiteSpace()
myString.IsNotNullOrWhiteSpace()
```

### Contains Extensions

When you must check if a given string contains an invalid character or characters like a path or customer number this might be useful:

```cs
if(path.ContainsAny('@', '|', '?'))
{
  // throw an error
}
```

Now I hear you say 'Why not use IndexOfAny instead?'. To that I answer with extensions that support a culture aware character comparer that `IndexOfAny` does not support.

```cs
if(email.ContainsAny(CharacterComparison.CurrentCultureIgnoreCase, 'ä', 'ü', 'ö'))
{
  // throw some error
}
```

This enables a case insensitive search for characters inside a string.
Equal to other apis there is support for other checks as well:

```cs
myString.ContainsAll('a','h')
myString.ContainsNone('x', 'y')
```

### Equals Extensions

When parsing some fixed set of valid strings against an enum or list of allowed values you can use this:

```cs
if(choice.EqualsAny("Yes", "No"))
{
  // do something
}
```

Or some set of strings is not allowed...

```cs
if(comment.EqualsNone(StringComparison.CurrentCultureIgnoreCase, 
   "Swearword1", "Swearword2", "Swearword3"))
{
  // allow this comment
}
```

### Substring shortcuts

When getting prefix of a string one always have to use some combination of `myString.Substring(0, myString.IndexOf(...))`.
Not only is this iterating through the string twice but also it is ugly to look at (in my opinion). Instead use this:

```cs
var leftSide = myString.Until('|');
var leftPart = myString.Until("theSuffix", StringComparison.InvariantCultureIgnoreCase);

var fileNameWithoutExtension = path.UntilLast('.');
var paragraph = text.UntilLast("\r\n");
```

### RegEx Match

When you want to quickly check a string against a regular expression pattern use this:

```cs
if(customerNumber.IsMatch(@"^\d{4}AAA\d{3}$"))
{
  // do something
}
```

This better than creating an instance of RegEx and matching against it. Of cause when you already have a static
pre-compiled instance if a RegEx you can just replace the pattern with that like:

```cs
private static readonly RegEx CustomerNumberRegEx = new RegEx(@"^\d{4}AAA\d{3}$", 
  RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));

// some other code

if(customerNumber.IsMatch(CustomerNumberRegEx))
{
  // do something
}
```

### Often used matches

Here are some quick-fire matches that all of used one day:

```cs
someString.IsBase64String()
someString.IsEmailAddress()
someString.IsUri()
someString.IsNumeric()
someString.IsAlphaNumeric()
```

### Counting occurrences of characters or strings

Sometimes it can be helpful to count all occurrences of a specific character inside a string.
For example if we want to know how deep a path is nested we can count the slashes like:

```cs
var folderStructureDepth = "somefolder/subfolder1/subfolder2/file.txt".CountOccurrences('/');
```

Another example can be to find duplicates in a list of otherwise unique values like:

```cs
var occurrences = "cat, dog, frog, fox, CAT".CountOccurences("Cat", StringComparison.CurrentCultureIgnoreCase);

if(occurrences > 1)
{
  // throw some error
}
```

### Anything missing?

Create an issue or pull request with extensions that are missing.

### Supported Frameworks

Currently supported frameworks are:

- [x] net45, net451, net452
- [x] net46, net461, net462
- [x] net47, net471, net472
- [x] net48
- [x] netstandard2.0, netstandard2.1

The standard versions of the package can be used in any netcoreapp like netcoreapp2.1/3.1 and net5.0.

## Community

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).

## License

All content for this video series made available in this repository is covered by the [MIT License](https://github.com/csharpfritz/csharp_with_csharpfritz/blob/main/LICENSE).
