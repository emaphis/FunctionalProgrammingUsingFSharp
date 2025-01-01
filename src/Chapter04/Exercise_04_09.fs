module Chapter04.Exercise_04_09

(*
Exercise 4.9

Declare an F# function zip such that:

    zip([x0;x1; . . . ;xn−1], [y0;y1; . . . ;yn−1])
    = [(x0, y0);(x1, y1); . . . ;(xn−1, yn−1)]

The function should raise an exception if the two lists are not of equal length.
*)



(*   Original method
    But I didn't like using concatenation, so I rewrote it using `reverse`

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
    if length xs <> length ys then raise DifferentLengths
    else
        let rec loop (xs, ys, zs) =
            match (xs, ys, zs) with
            | x::xs, y::ys, zs -> loop (xs, ys, (zs @ [(x, y)]))
            | _, _, zs -> zs

        loop (xs, ys, [])

// val zip: xs: 'a list -> ys: 'b list -> ('a * 'b) list
*)


exception DifferentLengths

/// Reverse a list
let reverse list =
    let rec loop acc = function
        | [] -> acc
        | x::xs -> loop (x::acc) xs
    loop [] list


/// Zip two lists
let zip (pairs : 'a list * 'b list) =
    let rec loop (aux: ('a * 'b) list, lst) =
        match lst with
        | x::xs, y::ys -> loop ((x,y)::aux, (xs, ys))
        | _::_, [] -> raise DifferentLengths
        | [], _::_ -> raise DifferentLengths
        | [], [] -> reverse aux

    loop ([], pairs)

//val zip: 'a list * 'b list -> ('a * 'b) list


(*
zip ([], []) = []
zip (["x0"], ["y0"]) = [("x0", "y0")]
zip (["x0"; "x1"], ["y0"; "y1"])  =  [("x0", "y0"); ("x1", "y1")]
zip ([0; 2; 4], [1; 3; 5]) = [(0, 1); (2, 3); (4, 5)]
*)
(*
reverse [] = []
reverse [0] = [0]
reverse [0;1] = [1;0]
reverse [0;1;2] = [2;1;0]
*)
