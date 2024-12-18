module Chapter02.Exercise_02_03_to_05

// Exercises 3 through 5 are the same series of exercises.

(*
    Exercise 2.3
    Declare the F# function isIthChar: string * int * char -> bool where the value of
    isIthChar(str, i, ch) is true if and only if ch is the i’th character in the string str (numbering
        starting at zero).
*)

/// String power function
let rec isIthChar(str: string, i, ch) =
    if str.Length < i then false
    else str[i] = ch

// val isIthchar: str: string * i: int * ch: char -> bool


(*
Exercise 2.4
Declare the F# function occFromIth: string * int * char -> int where

    occFromIth(str, i, ch) = the number of occurrences of character ch
                             in positions j in the string str with j ≥ i.

Hint: the value should be 0 for i ≥ size str
*)

/// Computes the number of occurences of character ch
/// in positions `j` in the string `str` with `j >= i`.
let rec occFromIth(str, i, ch) =
    if i >= String.length str then 0
    elif isIthChar(str, i, ch)
        then 1 + occFromIth(str, (i+1), ch)
        else occFromIth(str, (i+1), ch)

// val occFromIth: str: string * i: int * ch: char -> int


(*
Exercise 2.5
Declare the F# function `occInString: string * char -> int` where

    occInString(str, ch) = the number of occurrences of character `ch`
                           in the string `str`.
*)

/// Computes the number of occurrences of character `ch`
/// in the string `str`
let occInString(str, ch) =
    occFromIth(str, 0, ch)  // implement in terms of 2.4

// val occInString: str: string * ch: char -> int
