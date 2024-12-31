module Chapter04.Exercise_04_01

(*
Exercise 4.1
    Declare function upto: int -> int list such that upto n = [1; 2; ... ; n].
*)

/// Produce a list from 1 to n
let rec upto n =
    let rec loop n lst =
        match n with
        | 0 -> lst
        | x -> loop (x-1) (x::lst)

    loop n []

(*
upto 0 = []
upto 1 = [1]
upto 10 = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
*)
