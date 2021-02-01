# GenericUtility
Generic utility for .net 5

---

## Utility classes

---

## Extensions

Method extension grouped by namespace.

### Zu1779.GenUtil.Extension.BaseTypeExtension

#### Char extension
###### Definition
````csharp
// ToLower && ToUpper char instance extension
public static char ToUpper(this char character);
public static char? ToUpper(this char? character);
public static char ToLower(this char character);
public static char? ToLower(this char? character);
````
###### Usage
````csharp
char lowerCharacter = 'c';
char upperCharacter = 'D';
char toUpperCharacter = lowerCharacter.ToUpper();
char toLowerCharacter = upperCharacter.ToLower();
Console.WriteLine(toUpperCharacter); // 'C'
Console.WriteLine(toLowerCharacter); // 'd'
````

---
### Zu1779.GenUtil.Extension.CaseExtension
Transform a string to an IEnumerable\<string> of words based on case type.

Transform an IEnumerable\<string> of words to a string based on case type.

###### Definition
````csharp
public static IEnumerable<string> FromCamelCase(this string text);
public static IEnumerable<string> FromPascalCase(this string text);
public static IEnumerable<string> FromUnderscoreCase(this string text);
public static IEnumerable<string> FromSpaceCase(this string text);

public static string ToPascalCase(this IEnumerable<string> words);
public static string ToCamelCase(this IEnumerable<string> words);
public static string ToUnderscoreCase(this IEnumerable<string> words);
public static string ToJoinCase(this IEnumerable<string> words);
````
###### Usage
````csharp
// Just text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
IEnumerable<string> fromSC = "casual library user".FromSpaceCase(); // ["casual","library","user"]
// Just text.Split('-', StringSplitOptions.RemoveEmptyEntries);
IEnumerable<string> fromUC = "casual_library_user".FromUnderscoreCase(); // ["casual","library","user"]
// FromCamelCase and FromPascalCase have same code
IEnumerable<string> fromCC = "casualLibraryUser".FromCamelCase(); // ["casual","library","user"]
IEnumerable<string> fromPC = "CasualLibraryUser".FromPascalCase(); // ["casual","library","user"]

IEnumerable<string> words = new string[] { "casual", "library", "user" };
string toSpaceCase = words.ToSpaceCase(); // "casual library user"
string toUnderscoreCase = words.ToUnderscoreCase(); // "casual_library_user"
string toCamelCase = words.ToCamelCase(); // "casualLibraryUser"
string toPascalCase = words.ToPascalCase(); // "CasualLibraryUser"
````