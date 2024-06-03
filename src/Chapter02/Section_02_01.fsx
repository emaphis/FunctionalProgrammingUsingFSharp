// Chapter 2.1 Numbers. Truth values. The unit type

0
// val it: int = 0

0.0
// val it: float = 0.0

0123
//val it: int = 123

-388890
// val it: int = -388890

1.23e-17
// val it: float = 1.23e-17


// Operators

2 - - -1
// val it: int = 1

13 / -5
// val it: int = -2

13 % -5
// val it: int = 3


// Truth values:

true
// val it: bool = true

false
// al it: bool = false

// functions can have truth values as results
let even n = n % 2 = 0
// val even: n: int -> bool


not true <> false
// val it: bool = false


// The `unit` type

let unit1 = ()
// val unit1: unit = ()
