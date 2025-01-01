module Chapter04.Exercise_04_09

(*
Exercise 4.9

Declare an F# function zip such that:

    zip([x0;x1; . . . ;xn−1], [y0;y1; . . . ;yn−1])
    = [(x0, y0);(x1, y1); . . . ;(xn−1, yn−1)]

The function should raise an exception if the two lists are not of equal length.
*)


exception DifferentLengths

/// Compute length of lists
let length xs : int =
    let rec loop xs n =
        match xs with
        | []  -> n
        | _::xs -> loop xs n+1

    loop xs 0


/// Zip two lists
let zip xs ys  =
    let rec loop (xs, ys, zs) =
        if length xs <> length ys then raise DifferentLengths
        else
            match (xs, ys, zs) with
            | x::xs, y::ys, zs -> loop (xs, ys, (zs @ [(x, y)]))
            | _, _, zs -> zs

    loop (xs, ys, [])


(*
length [] = 0
length [0] = 1
length [0;1;2] = 3
*)

(*
zip [] [] = []
zip ["x0"] ["y0"] = [("x0", "y0")]
zip ["x0"; "x1"] ["y0"; "y1"] =  [("x0", "y0"); ("x1", "y1")]
zip [0; 2; 4] [1; 3; 5] = [(0, 1); (2, 3); (4, 5)]
*)
