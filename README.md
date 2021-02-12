# Verticular String Extensions

This repository contains the dotnet [https://docs.microsoft.com/de-de/dotnet/api/system.string](String) Extension methods that you were missing all those years.

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
if(comment.EqualsNone(StringComparison.CurrentCultureIgnoreCase, "Swearword1", "Swearword2", "Swearword3"))
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

### Often used matches

Here are some quick-fire matches that all of used one day:

```cs
someString.IsBase64String()
someString.IsEmailAddress()
someString.IsUri()
someString.IsNumeric()
someString.IsAlphaNumeric()
```

### Anything missing?

Create an issue or pull request with extensions that are missing.

## Community

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).

## License

All content for this video series made available in this repository is covered by the [MIT License](https://github.com/csharpfritz/csharp_with_csharpfritz/blob/main/LICENSE).
