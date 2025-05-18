// 2.3 Characters and strings

// chars

'a'
// val it: char = 'a'

' '
// val it: char = ' '


//    Character escape sequences
//    Sequence    Meaning
//    --------    -------
//    \'          Apostrophe
//    \"          Quote
//    \\          Backslash
//    \b          Backspace
//    \n          NewLine
//    \r          Carriage return
//    \t          Horizontal tax


// Using e operators ||, && and not in char expressions

let isLowerCaseVowel ch  =
    ch='a' || ch='e' || ch='i' || ch='o' || ch='u'

let isLowerCaseConsonant ch =
    System.Char.IsLower ch && not (isLowerCaseVowel ch)

isLowerCaseVowel 'i' && not (isLowerCaseConsonant 'i')
// val it: bool = true

isLowerCaseVowel 'I' || isLowerCaseConsonant 'I'
// val it: bool = false

not (isLowerCaseVowel 'z') && isLowerCaseConsonant 'z'
// val it: bool = true


// Strings

"abcd---"
// val it: string = "abcd---"

"\"1234\""
// val it: string = ""1234""

""
// val it: string = ""

// Verbatim string notation:

@"c0 c1 ... cn−1"
// val it: string = "c0 c1 ... cn−1"

@"\\\\"
// val it: string = "\\\\"

"\\\\"
// val it: string = "\\"


// Funtions on strings

String.length "1234"
// val it: int = 4

String.length "\"1234\""
// val it: int = 6

String.length ""
// val it: int = 0

// concatenation

let text = "abcd---"
// val text: string = "abcd---"

text + text
// val it: string = "abcd---abcd---"

text + " " = text
// val it: bool = false

text + "" = text
// val it: bool = true

"" + text = text
// val it: bool = true

// Strings are zero indexed
"abc"[0]
// val it: char = 'a'

"abc"[2]
// val it: char = 'c'

"abc"[3]
// ystem.IndexOutOfRangeException: Index was outside the bounds of the array.

// concatenating strings and chars

"abc" + string 'd'
// val it: string = "abcd"

// Using the `string` conversion operator

string -4
// val it: string = "-4"

string 7.89
// val it: string = "7.89"

string true
// val it: string = "True"

// Using `string` in functions

let nameAge(name, age) =
    name + " is " + (string age) + " years old."

nameAge ("Diana", 15+4)
// al it: string = "Diana is 19 years old."

nameAge ("Philip", 1-4)
// val it: string = "Philip is -3 years old."

// `string` can create strings of compound and user defined types.

string (12, 'a')
// val it: string = "(12, a)"

string nameAge
// val it: string = "FSI_0053+it@135"
