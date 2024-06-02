module Chapter01.Exercise_04

(*
   1.4 Declare a recursive function f: int -> int, where
       
            f(n)=1+2+ ··· + (n − 1) + n
       
       for `n >= 0`. (Hint: use two clauses with 0 and n as patterns.)
       
       State the recursion formula corresponding to the declaration.
       
       Give an evaluation for f(4)
*)

/// Sums numbers from 0 to the given integer `n`
let rec f = function
    | 0 -> 0
    | n -> n + f (n - 1)

// val f: _arg1: int -> int

// Recursion formula

// f(0)  = 0
// f(n) = n + f(n-1)  for n>0


// Evaluation for f(4)

// f 4
// 4 + f (4-1)
// 4 + 3 + f (3-1)
// 4 + 3 + 2 + f(2-1)
// 4 + 3 + 2 + 1 + f(1-1)
// 4 + 3 + 2 + 1 + 0
// 10
