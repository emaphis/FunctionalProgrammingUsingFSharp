module Chapter02.Exercise_02_02


(*
    Exercise 2.2
    Declare an F# function pow: string * int -> string, where:

            pow(s,n) = s . s . ... . s
                       \_____________/
                              n

    where we use · to denote string concatenation. (The F# representation is +.)
*)

/// String power function
let rec pow(s, n) =
    match s, n with
    | _, n when n = 0 -> ""
    | s, n  -> s + pow(s, n-1)

// val pow: s: string * n: int -> string


let test1 = pow("a", 0)
let test2 = pow("a", 1)
let test3 = pow("a", 3)
let test4 = pow("", 3)
