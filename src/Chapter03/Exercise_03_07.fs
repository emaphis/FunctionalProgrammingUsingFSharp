module Chapter03.Exercise_03_07

(*
Exercise 3.7

   Give a declaration for the area functionon Page61 using guarded patterns rather than an
   'if...then...else' expression.
*)


type Shape =
    | Circle of float
    | Square of float
    | Triangle of float * float * float


/// Check for shape invariants
let isShape = function
    | Circle r      -> r > 0.0
    | Square a      -> a > 0.0
    | Triangle (a, b, c) ->
        a > 0.0 && b > 0.0 && c > 0.0
        && a < b + c && b < a + c && c < a + b


let area shp =
    match shp with
    | shp when not (isShape shp) -> failwith "not a legal shape"
    | Circle r   -> System.Math.PI * r * r
    | Square a   -> a * a
    | Triangle (a, b ,c) ->
        let s = (a + b + c) / 2.0
        sqrt(s * (s - a) * (s - b) * (s - c))
