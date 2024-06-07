module Chapter02.Exercise_02_12

(*
    Exercise 2.12

    Declare a function min of type `(int -> int) -> int`. The value of min(f) is the smallest
    natural number n where f(n)=0 (if it exists).
*)

[<TailCall>]
let rec min' f n =
    if f n = 0 then n
    else if n = 9999999 then 0
    else min' f (n+1)

/// Find the lowest integer value where `f` = 0
let min f =
    min' f -9999999

// val min: f: (int -> int) -> int

// TODO: whateverS
