module Chapter02.Exercise_02_03


(*
    Exercise 2.3
    Declare the F# function isIthChar: string * int * char -> bool where the value of
    isIthChar(str, i, ch) is true if and only if ch is the i’th character in the string str (numbering
        starting at zero).
*)

/// String power function
let rec isIthchar(str: string, i, ch) =
    str[i] = ch

// val isIthchar: str: string * i: int * ch: char -> bool
