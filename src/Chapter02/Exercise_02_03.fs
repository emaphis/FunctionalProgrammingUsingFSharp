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


let test1 = isIthchar("a", 0, 'a')
let test2 = isIthchar("abc", 0, 'a')
let test3 = isIthchar("c", 0, 'b') |> not
let test4 = isIthchar("abc", 1, 'b')
let test5 = isIthchar("abc", 1, 'c') |> not
