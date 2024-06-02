module Chapter01.Exercise_05

(*
   Exercise 1.5
   The sequence `F0, F1, F2,..`. of Fibonacci numbers is defined by:
   
   F0 = 0
   F1 = 1
   Fn = Fn−1 + Fn−2
   
   Thus, the first members of the sequence are 0, 1, 1, 2, 3, 5, 8, 13,....
   Declare an F# function to compute Fn. Use a declaration with three clauses, where the patterns
   correspond to the three cases of the above definition.
   Give an evaluations for F4.
*)

/// Calculates the Fibonacci sequence.
let rec f = function
    | 0 -> 0
    | 1 -> 1
    | n -> f (n - 1) + f(n - 2)

// val f: _arg1: int -> int



// Evaluation for f 4

// f 4
// -> f (4-1) + f (4-2)
// -> f 3 + f 2
// -> f (3-1) + f (3-2) + f (2-1) + f (2-2)
// -> f 2 + f 1 + f 1 + f 0
// -> f (2-1) + f (2-2) + 1 + 1 + 0
// -> f 1 + f 0 + 1 + 1 + 0
// -> 1 + 0 + 1 + 1 + 0
// -> 3
