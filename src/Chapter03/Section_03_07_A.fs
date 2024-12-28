module Chapter03.Section_03_07_A


type QNum = int * int  // (a,b) where b <> 0

exception QDiv

let mkQ pair : QNum =
 match pair with
 | _, 0 -> raise QDiv
 | a, b -> a, b

//val mkQ: 'a * int -> 'a * int

let rec gcd (m, n) =
    if m = 0 then n
    else gcd (n % m, m)

// val gcd: m: int * n: int -> int

// The operators

/// Addition
let (.+.) (a, b) (c, d) = (a*d + b*c, b*d)

/// Subtraction
let (.-.) (a, b) (c, d) = (a*d - b*c, b*d)

/// Multiplication
let (.*.) (a, b) (c, d) = (a*c, b*d)

/// Division
let (./.) (a, b) (c, d) = (a,b) .*. mkQ(d,c)

/// Equality
let (.=.) (a, b) (c, d) = (a, b) = (c, d)


/// Produce textual representation
let toString(p, q) =
    let sign = if p*q < 0 then "-" else ""
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    sign + (ap / d).ToString() +
         "/" + (aq / d).ToString()

//val toString: p: int * q: int -> string

// Tests:
(*
//mkQ(3, 0)
// val toString: p: int * q: int -> string

let q1 = mkQ(2, -3)
//val q1: QNum = (2, -3)

let q2 = mkQ(5, -10)
// val q2: QNum = (5, -10)

let q3 = q1 .+. q2
//val q3: int * int = (-35, 30)

let q3a = q1 .-. q2
//al q3a: int * int = (-5, 30)

let q4 = q2 .*. q3
//val q4: int * int = (-175, -300)

let q5 = q4 ./. q3
// val q5: int * int = (-5250, 10500)

let b1 = q1 .=. q2
//val b1: bool = false

let cd1 = gcd(0, 5)
//val cd1: int = 5

let cd2 = gcd(3, 5)
//val cd2: int = 1

let cd3 = gcd(3, 15)
//val cd3: int = 3

let str1 = toString q4
//val str1: string = "7/12"

let str2 = toString q5
//val str2: string = "-1/2"
*)