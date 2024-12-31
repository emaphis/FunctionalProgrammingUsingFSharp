module Chapter04.Exercise_04_02

(*
Exercise 4.2
  Declare function downto1: int -> int list such that the value of downto1 n is the list
  [n; n − 1; ... ; 1]
*)

let rec downto1 n = 
    match n with
    | 0 -> []
    | _ -> n :: downto1 (n-1)


(*
downto1 0 = []
downto1 1 = [1]
downto1 5 = [5; 4; 3; 2; 1]
*)
