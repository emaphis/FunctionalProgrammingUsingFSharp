// 2.9 Declaring prefix and infix operators

// The infix operators:
// ! % & * + - . / < = > ? @ ˆ | ˜

// The prefix operators
// + - +. -. & && % %%
// ˜ ˜˜ ˜˜˜ ˜˜˜˜

// The `bracket notation` converts from infix of prefix
// operator to (prefix) function.


// infix operator is declared using the bracket notation 

let (.||.) p q = (p || q) && not (p && q)
// val (.||.) : p: bool -> q: bool -> bool

(1 > 2) .||. (2 + 3 < 5)
// val it: bool = false

// Operator precedence is the same as the underlying `||`

true .||. false && true
// val it: bool = true

// is equivalent to,
true .||. false && true


// A prefix operator is declared using a leading tilde character.
let (~%%) x = 1.0 / x
//val (~%%) : x: float -> float

let num1 = %% 0.5
// val num1: float = 2.0
