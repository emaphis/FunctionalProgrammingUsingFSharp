module Chapter04.Exercise_04_10

(*
Exercise 4.10

    Declare an F# function prefix: ’a list -> ’a list -> bool when a : equality.
    The value of the expression prefix [x0;x1; . . . ;xm] [y0;y1; . . . ;yn] is true if m ≤ n
    and xi = yi for 0 ≤ i ≤ m, and false otherwise.
*)


/// tests to see if the first m of of [1..m..n] of two lists are equal
let rec prefix xs ys =
    match xs, ys with
    | x::xs, y::ys -> (x=y) && prefix xs ys // prefix [x0;x1; . . . ;xm] [y0;y1; . . . ;yn]
    | [], _ -> true    // is true if m ≤ n
    | _     -> false   // false otherwise

// val prefix: xs: 'a list -> ys: 'a list -> bool when 'a: equality

(*
prefix [] []  = true
prefix [] [1] = true
prefix [1] [] = false
prefix [1] [1] = true
prefix [1] [1;2] = true
prefix [1;2] [1] = false
prefix [1;2;3;4] [1;2;3;4;5;6] = true
*)
