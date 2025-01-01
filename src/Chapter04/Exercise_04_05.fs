module Chapter04.Exercise_04_05

(*
Exercise 4.5
    Declare an F# function `rmodd` removing the odd-numbered elements from a list:

        `rmodd` [x0;x1;x2;x3; . . . ] = [x0;x2; . . . ]
*)

let isOdd n = n % 2 = 1

/// Remove the odd numbered elements from a given list
let rec rmodd = function
    | []        -> []
    | x::xs when isOdd x -> rmodd xs
    | x::xs -> x :: rmodd xs


(*
rmodd [] = []
rmodd [2] = [2]
rmodd [1;2;3] = [2]
rmodd [1;2;3;4] = [2;4]
rmodd [0;2;3;8] = [0;2;8]
*)
