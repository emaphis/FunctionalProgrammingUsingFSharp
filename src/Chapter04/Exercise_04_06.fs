module Chapter04.Exercise_04_06


(*
Exercise 4.6
    Declare an F# function to remove even numbers occurring in an integer list.
*)

/// Remove the even numbered elements from a given list
let rec rmeven = function
    | []        -> []
    | _::x1::xs -> x1 :: rmeven xs
    | _::xs     -> xs


(*
rmeven [0] = []
rmeven [0;1] = [1]
rmeven [0;1;2] = [1]
rmeven [0;1;2;3] = [1;3]
rmeven [0;1;2;3;4] = [1;3]
rmeven [0;1;2;3;4;5] = [1;3;5]
*)