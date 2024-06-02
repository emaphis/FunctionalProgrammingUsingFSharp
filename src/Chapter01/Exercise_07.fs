module Chapter01.Exercise_07

(*
   Exercise 1.7
   Determine a type for each of the expressions:
   (System.Math.PI, fact -1)
   fact(fact 4)
   power(System.Math.PI, fact 2)
   (power, fact)
 *)

 
let rec fact = function
    | 0 -> 1                                // Clause 1
    | n -> n * fact (n - 1)

let rec power = function
    | (x,0) -> 1.0
    | (x,n) -> x * power (x, n-1)


// Determine a type for each of the expressions:

let type1 = (System.Math.PI, fact -1)
// float * int  => Error


let type2 = fact(fact 4)
// int

let type3 = power(System.Math.PI, fact 2)
// float

let type4 = (power, fact)
// (float * int -> float) * (int -> int)
