module Chapter04.Exercise_04_Examples

(*
Some exercises from Hansen SML book.

Exercise 5.6
  Give declarations for the SML functions: length, nth, take and drop in
  Section 5.6.3.
*)


/// Reverse a list
let reverse list =
    let rec loop acc = function
        | [] -> acc
        | x::xs -> loop (x::acc) xs
    loop [] list



/// Return the length of a list
let length' xs =
    let rec loop xs n =
        match xs with
        | []  -> n
        | _::xs -> loop xs (n+1)

    loop xs 0

(*
length' [] = 0
length' [1] = 1
length' [1;2] = 2
length' [1;2;3] = 3
*)

/// Return the `nth` element of a list
let rec nth (list, n) =
    match list with
    | []              -> failwith "List is too short"
    | x::_ when n = 0 -> x
    | _::xs           -> nth (xs, n-1)


(*
nth ([1], 0) = 1
nth ([1; 2], 0) = 1
nth ([1; 2; 3], 2) = 3   // book example
//nth ([1; 2; 3], 3)
//System.Exception: List is to short
*)

/// Take the first nth elements of a list
let take (lst, n) =
    let rec loop (xs, k, acc) =
        match k with
        | 0 -> reverse acc
        | k ->
            match xs with
            | [] -> failwith "List is too short"
            | y::ys -> loop (ys, (k - 1), y::acc)
    loop (lst, n, [])

(*
take ([1], 0) = []
take ([1;2], 1) = [1]
take ([1;2], 2) = [1; 2]
take ([0;1;2;3;4;5;6], 4) = [0; 1; 2; 3]  // book example
*)

/// let rec drop (xs, n) =
let rec drop  (xs, n) =
   match xs, n with
   | [], _   -> []
   | xs, 0   -> xs
   | x::xs, n -> drop (xs, (n-1))

(*
drop ([], 0) = []
drop ([1;2;3], 0) = [1; 2; 3]
drop ([1;2;3], 1) = [2; 3]
drop ([1;2;3], 2) = [3]
drop ([1;2;3], 3) = []
drop([0; 1; 2; 3; 4; 5; 6], 4) = [4; 5; 6]  // book example
*)
