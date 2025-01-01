module Chapter04.Exercise_04_07

(*
Exercise 4.7
    Declare an F# function multiplicity x xs to find the number of times the value x occurs
    in the list xs.
*)

/// find the number of times the value x occurs in the list xs.
let multiplicity x xs =
    let rec loop xs n =
        match xs, n with
        | [], n               -> n
        | x'::xs, n when x'=x -> loop xs (n+1)
        | _::xs, n            -> loop xs n
    loop xs 0

//val multiplicity: x: 'a -> xs: 'a list -> int when 'a: equality


(*
multiplicity 1 [] = 0
multiplicity 1 [1] = 1
multiplicity 1 [1;2;3;4] = 1
multiplicity 1 [1;2;1;4] = 2
multiplicity 1 [1;1;1;1] = 4
multiplicity 'a' ['b';'c';'a';'e';'a'] = 2
*)
