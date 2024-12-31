module Chapter04.Exercise_04_03

(*
Exercise 4.3
    Declare function `evenN: int -> int list` such that evenN n generates the list of the first
    `n` non-negative even numbers.
*)


let rec evenN n =
    let rec loop n lst =
        match n with
        | 0 -> lst
        | x -> loop (x-1) ((x*2) :: lst)

    loop n []

(*
evenN 0 = []
evenN 1 = [2]
evenN 5 = [2; 4; 6; 8; 10]
*)
