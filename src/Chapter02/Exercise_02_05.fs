module Chapter02.Exercise_02_05


(*
    Exercise 2.5
    Declare the F# function `occInString: string * char -> int` where

        occInString(str, ch) = the number of occurrences of character `ch`
                               in the string `str`.
*)

// Use from isIthchar Exercise 2.3

let isIthchar(str: string, i, ch) =    str[i] = ch

// Use occFromIth for Exercise. 2.4

/// Occurrences of char ch from i.
let rec occFromIth(str, i, ch) =
    if i >= String.length str
    then 0
    else if isIthchar(str, i, ch)
        then 1 + occFromIth(str, (i+1), ch)
        else occFromIth(str, (i+1), ch)


/// Computes the number of occurrences of character `ch`
/// in the string `str`
let occInString(str, ch) =
    occFromIth(str, 0, ch)  // implement in terms of 2.4

// val occInString: str: string * ch: char -> int
