module Chapter04.Exercise_04_02

(*
Exercise 4.2
  Declare function downto1: int -> int list such that the value of downto1 n is the list
  [n; n − 1; ... ; 1]
*)

let rec downto1 n = 
    let rec loop n lst =
        match n, lst with
        | 0, lst -> lst
        | _, lst -> n :: loop (n-1) lst

    loop n []


(*
downto1 0 = []
downto1 1 = [1]
downto1 5 = [5; 4; 3; 2; 1]
*)
