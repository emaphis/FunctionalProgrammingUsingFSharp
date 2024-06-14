// 3.7 Example: Rational numbers. Invariants

module Chapter03.Section_03_07

// A rational number `q` is a fraction `q=a/b` where 'a' and 'b' are integers with `b <> 01.
    
// Representation, Invariant.
// We use (a,b) where b>0 and a/b is irreducable where `gcd(a,b) = 1`.
// The value (a,b) of type `int * int` where `b != 0` and `gcd(a,b) = 1` is the
// `invariant` of rational numbers.

type Qnum = int * int  // (a,b) where b > 0 and gcd(a,b) = 1


let rec gcd (m, n) =
    if m=0 then n
    else gcd (n % m, m)


// Operators.

/// Cancels common divisors so reduces any fraction with a non-zero denominator to
/// the normal form.
let canc(p, q) =
    let sign = if p*q < 0 then -1 else 1
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    (sign * (ap / d), aq / d)

// val canc: p: int * q: int -> int * int

/// Enforce the invariants.
let mkQ =
    function
    | (_,0)  -> failwith "Division by zero"
    | pr -> canc pr

// val mkQ: int * int -> int * int

// Operators on rational numbers

/// Adition
let (.+.) (a, b) (c, d) = canc(a*d + b*c, b*d)

/// Subtraction
let (.-.) (a, b) (c, d) = canc(a*d - b*c, b*d)

/// Multiplication
let (.*.) (a, b) (c, d) = canc(a*c, b*d)

/// Division
let (./.) (a, b) (c, d) = (a,b) .*. mkQ(d,c)

/// Equality
let (.=.) (a,b) (c,d) = (a,b) = (c,d)

let toString(p:int,q:int) = (string p) + "/" + (string q)


// Examples

let q1 = mkQ(2,-3)
// val q1: int * int = (-2, 3)

let q2 = mkQ(5,10)
// val q2: int * int = (1, 2)

let q3 = q1 .+. q2
// val q3: int * int = (-1, 6)

let num1 = toString(q1 .-. q3 ./. q2)
// val num1: string = "-1/3"
