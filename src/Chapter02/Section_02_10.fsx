// 2.10 Equality and ordering


// The equality and inequality operators = and <> are defined on any basic type and on strings:

// equality

let bool1 = 3.5 = 2e-3
// val bool1: bool = false

let bool2 = "abc" <> "ab"
// al bool2: bool = true

// Not defined on functions / closures:

// let bool3 = cos = sin
// error FS0001: The type '('a -> 'a)' does not support the 'equality' constraint because it is a function type

// The equality function is automatically extended by F# whenever the user defines a new type

let eqText x y =
    if x = y then "equal" else "not equal"

// val eqText: x: 'a -> y: 'a -> string when 'a: equality

let str1 = eqText 2 4
// val str1: string = "not equal"

let str2 = eqText ' ' (char 32)
// val str2: string = "equal"


// Ordering

// Operators:  >, >=, <, and <=

// Upper case letters precede
// lower case letters

let sort1 = 'A' < 'a'
// val bool3: bool = true

let sort2 = "automobile" < "car"
// val bool4: bool = true

let sort3 = "" < " "
// val sort3: bool = true


// Using the comparison operators one may declare functions on values of an arbitrary type
// equipped with an ordering:

let ordText1 x y =
    if x > y then "greater"
    else if x = y then "equal"
    else "less"

// val ordText: x: 'a -> y: 'a -> string when 'a: comparison

// The library function `compare` is defined such that:

//               | > 0   if x > y
// compare x y = |   0   if x = y
//               | < 0   if x < y

// where the precise value of compare x y depends on the structure
// of the values x and y.

let ordText2 x y =
    match compare x y with
    | t when t > 0 -> "greater"
    | 0               -> "equal"
    | _               -> "less"

// val ordText2: x: 'a -> y: 'a -> string when 'a: comparison

