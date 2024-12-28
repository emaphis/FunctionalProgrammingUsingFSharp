module Chapter03.Section_03_07_C

// Rational numbers implemented wit a record


type QNum = { Num : int; Denom : int }   // Denom <> 0

let rec gcd (m, n) =
    if m = 0 then n
    else gcd (n % m, m);;

// val gcd: m: int * n: int -> int


/// Cancels common divisors and reduces the fraction p/q to its normal form
let canc(p, q) : QNum =
    let sign = if p*q < 0 then -1 else 1
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    { Num = sign * (ap / d)
      Denom = aq / d}

//val canc: p: int * q: int -> int * int

exception QDiv;

/// Enforce the invariants.
let mkQ =
    function
    | _, 0  -> raise QDiv
    | pr    -> canc pr

// val mkQ: int * int -> int * int

// Operators on rational numbers

/// Addition
let (.+.) { Num = a; Denom = b} {Num = c; Denom =d} = canc(a*d + b*c, b*d)

/// Subtraction
let (.-.) { Num = a; Denom = b} {Num = c; Denom =d} = canc(a*d - b*c, b*d)

/// Multiplication
let (.*.) { Num = a; Denom = b} {Num = c; Denom =d} = canc(a*c, b*d)

/// Division
let (./.) { Num = a; Denom = b} {Num = c; Denom =d} = mkQ(a, b) .*. mkQ(d,c)

/// Equality
let (.=.) { Num = a; Denom = b} {Num = c; Denom =d} = (a,b) = (c,d)

let toString { Num = p; Denom = q} = (string p) + "/" + (string q)



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
//val qna: QNum = { Num = 1; Denom = 2 }

let qnB = canc(-5, 10)
//val qnB: QNum = { Num = -1;  Denom = 2 }

//mkQ(3, 0)
// val toString: p: int * q: int -> string

let q1 = mkQ(2, -3)
//val q1: QNum = { Num = -2; Denom = 3 }

let q2 = mkQ(5, 10)
// val q2: QNum = { Num = 1; Denom = 2 }


let q3 = q1 .+. q2
//val q3: int * int = { Num = -1; Denom = 6 }

let q3a = q1 .-. q2
//al q3a: int * int = { Num = -7; Denom = 6 }

let q4 = q2 .*. q3
//val q4: int * int = { Num = -1; Denom = 12 }

let q5 = q4 ./. q3
// val q5: int * int = { Num = 1; Denom = 2 }

let b1 = q1 .=. q2
//val b1: bool = false


let str1 = toString q3
//val str1: string = "-1/6"

let str2 = toString q5
//val str2: string = "1/2"

*)