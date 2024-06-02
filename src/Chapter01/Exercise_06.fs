module Chapter01.Exercise_06

(*
   Exercise 1.6
   Declare a recursive function sum: int * int -> int, where
   
        sum(m, n) = m + (m + 1) + (m + 2) + ··· + (m + (n − 1)) + (m + n)
   
   for m ≥ 0 and n ≥ 0. (Hint: use two clauses with (m,0) and (m,n) as patterns.)
   
   Give the recursion formula corresponding to the declaration
*)

/// Sum `m` an `n` number of times
let rec sum (m, n) =
    match m, n with
    | (m, 0) -> m
    | (m, n) -> (m+n) + sum (m , n - 1)

// val sum: m: int * n: int -> int

// Recursion formula

// sum (m, 0) = 0
// sum (m, n) = m + (m + n)
