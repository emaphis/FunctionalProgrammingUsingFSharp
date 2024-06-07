module Chapter02.Exercise_02_06


(*
    Exercise 2.6
    Declare the F# function `notDivisible: int * int -> bool` where
   
        notDivisible(d, n) is true if and only if `d` is not a divisor of `n`.

    For example 'notDivisible(2,5)' is true, and 'notDivisible(3,9)' is fal
*)

/// True if and only if `d` is not a divisor of `n`.

let notDivisible(d, n) = n % d <> 0
// val notDivisible: d: int * n: int -> bool
