module Chapter02.Exercise_02_01

(*
    Exercise 2.1
    Declare a function f: int -> bool such that f(n) = true exactly when n is divisible by 2
    or divisible by 3 but not divisible by 5. Write down the expected values of f(24), f(27), f(29)
    and f(30) and compare with the result. Hint: n is divisible by q when n%q = 0.
*)

/// Return true if 'n' is divisible by 2 and 3 but not 5
let f n =
    let divBy num n = num % n = 0
    (not (divBy n 5)) && (divBy n 2 || divBy n 3)

// val f: n: int -> bool

//f(24) = true
//f(27) = true
//f(29) = false
//f(30) = false
