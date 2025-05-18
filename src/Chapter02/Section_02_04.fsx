// 2.4 If-then-else expression

// Has the form:
// if exp1 then exp2 else exp3
// where exp1 is an expression of type `bool`
// and exp2 exp3 are expressions of the same type

// If expressions are useful ins situations aere splitting
// into cases is inconvenient.


//  a function on strings that adjusts a string to even size
// by putting a space character in front of the string if
// the size is odd.

let even n = n % 2 = 0

let adjString s =
    if even (String.length s)
    then s else " " + s

// val adjString: s: string -> string

adjString "123"
// val it: string = " 123"

adjString "1234"
// val it: string = "1234"


// Pattern matching is to be preferred as highlighted by this
// less readable GCD definition

let rec gcd(m, n) =
    if m=0 then n
    else gcd (n % m, m)

// val gcd: m: int * n: int -> int
