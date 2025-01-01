module Chapter04.Exercise_04_05

(*
Exercise 4.5
    Declare an F# function `rmodd` removing the odd-numbered elements from a list:

        `rmodd` [x0;x1;x2;x3; . . . ] = [x0;x2; . . . ]
*)

/// Remove the odd numbered elements from a given list
let rec rmodd = function
    | []        -> []
    | x0::_x1::xs -> x0 :: rmodd xs
    | x2::xs    -> x2::xs


(*
rmodd [] = []
rmodd [0] = [0]
rmodd [0;1] = [0]
rmodd [0;1;2] = [0;2]
rmodd [0;1;2;3] = [0;2]
rmodd [0;1;2;3;4] = [0;2;4]
rmodd [0;1;2;3;4;5] = [0;2;4]
*)