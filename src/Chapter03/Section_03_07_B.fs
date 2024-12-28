// 3.7 Example: Rational numbers. Invariants

module Chapter03.Section_03_07_B

// A rational number `q` is a fraction `q=a/b` where 'a' and 'b' are integers with `b <> 01.
    
// Representation, Invariant.
// We use (a,b) where b>0 and a/b is irreducible where `gcd(a,b) = 1`.
// The value (a,b) of type `int * int` where `b != 0` and `gcd(a,b) = 1` is the
// `invariant` of rational numbers.

///  (a,b) where b > 0 and gcd(a,b) = 1
type QNum = int * int


let rec gcd (m, n) =
    if m=0 then n
    else gcd (n % m, m)


// Operators.

/// Cancels common divisors so reduces any fraction with a non-zero denominator to
/// the normal form.
let canc(p, q) : QNum =
    let sign = if p*q < 0 then -1 else 1
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    (sign * (ap / d), aq / d)

// val canc: p: int * q: int -> int * int

exception QDiv;

/// Enforce the invariants.
let mkQ =
    function
    | _,0  -> raise QDiv
    | pr -> canc pr

// val mkQ: int * int -> int * int

// Operators on rational numbers

/// Addition
let (.+.) (a, b) (c, d) = canc(a*d + b*c, b*d)

/// Subtraction
let (.-.) (a, b) (c, d) = canc(a*d - b*c, b*d)

/// Multiplication
let (.*.) (a, b) (c, d) = canc(a*c, b*d)

/// Division
let (./.) (a, b) (c, d) = (a,b) .*. mkQ(d,c)

/// Equality
let (.=.) (a, b) (c,d) = (a,b) = (c,d)

let toString(p:int, q:int) = (string p) + "/" + (string q)


// Examples
// Tests:
(*
let cd1 = gcd(0, 5)
//val cd1: int = 5

let cd2 = gcd(3, 5)
//val cd2: int = 1

let cd3 = gcd(3, 15)
//val cd3: int = 3


let qna = canc(5, 10)
//val qna: QNum = (1, 2)

let qnB = canc(-5, 10)
//val qnB: QNum = (-1, 2)

//mkQ(3, 0)
// val toString: p: int * q: int -> string

let q1 = mkQ(2, -3)
//val q1: QNum = (-2, 3)

let q2 = mkQ(5, 10)
// val q2: QNum = (1, 2)


let q3 = q1 .+. q2
//val q3: int * int = (-1, 6))

let q3a = q1 .-. q2
//al q3a: int * int = (-7, 6)

let q4 = q2 .*. q3
//val q4: int * int = (-1, 12)

let q5 = q4 ./. q3
// val q5: int * int = (1, 2)

let b1 = q1 .=. q2
//val b1: bool = false


let str1 = toString q3
//val str1: string = "-1/6"

let str2 = toString q5
//val str2: string = "1/2"
*)
