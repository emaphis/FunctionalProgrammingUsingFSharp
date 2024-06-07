module Chapter02.Exercise_02_04


(*
    Exercise 2.4
    Declare the F# function occFromIth: string * int * char -> int where
    
        occFromIth(str, i, ch) = the number of occurrences of character ch
                                 in positions j in the string str with j ≥ i.
    
    Hint: the value should be 0 for i ≥ size str
*)

// Use from isIthchar Exercise 2.3
let isIthchar(str: string, i, ch) =    str[i] = ch

/// Computes the number of occurences of character ch
/// in positions `j` in the string `str` with `j >= i`.
let rec occFromIth(str, i, ch) =
    if i >= String.length str
    then 0
    else if isIthchar(str, i, ch)
        then 1 + occFromIth(str, (i+1), ch)
        else occFromIth(str, (i+1), ch)

// val occFromIth: str: string * i: int * ch: char -> int
