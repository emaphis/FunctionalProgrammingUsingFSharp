module Chapter04.Exercise_04_04

(*
Exercise 4.4
    Give a declaration for altsum (see Page 76) containing just two clauses.
*)


// Old definition
let rec altsum' = function
    | []         -> 0
    | [x]        -> x
    | x0::x1::xs -> x0 - x1 + altsum' xs;;


let res' = altsum' [2; -1; 3] = 6


// This is not obvious to me but it evaluates correctly.

let rec altsum = function
    | []     -> 0
    | x0::xs -> x0 - altsum xs


let res = altsum [2; -1; 3] = 6
