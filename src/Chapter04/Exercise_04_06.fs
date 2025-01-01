module Chapter04.Exercise_04_06


(*
Exercise 4.6
    Declare an F# function to remove even numbers occurring in an integer list.
*)

let isEven n = n % 2 = 0

/// Remove the even numbered elements from a given list
let rec rmeven = function
    | []        -> []
    | x::xs when isEven x -> rmeven xs
    | x::xs -> x :: rmeven xs


(*
rmeven [] = []
rmeven [0] = []
rmeven [0;1] = [1]
rmeven [0;1;2] = [1]
rmeven [1;4;2;3] = [1;3]
rmeven [5;1;2;3;4] = [5;1;3]
rmeven [0;1;2;3;4;5] = [1;3;5]
*)
