module Chapter04.Exercise_04_08


(*
Exercise 4.8
   Declare an F# function split such that:

       split [x0;x1;x2;x3; . . . ;xn−1] = ([x0;x2; . . . ], [x1;x3; . . . ])
*)

 /// Split the ...
let split xs =
    let rec loop xs ys zs =
        match xs, ys, zs with
        | [], _, _   -> (ys, zs)
        | x0::x1::xs, ys, zs -> loop xs (ys @ [x0]) (zs @ [x1])
        | [x], ys, zs -> (ys @ [x], zs)

    loop xs [] []

//val split: xs: 'a list -> 'a list * 'a list

(*
split ([]: int list) = ([], [])
split [0] = ([0], [])
split [0;1] = ([0], [1])
split [0;1;2] = ([0; 2], [1])
split [0;1;2;3] = ([0; 2], [1; 3])
split [0;1;2;3;4] = ([0; 2; 4], [1; 3])
split ['a';'b';'c'] = (['a';'c'], ['b'])
*)
