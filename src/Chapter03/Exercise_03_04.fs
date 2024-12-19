module Chaper03.Exercise03_04

(*
Exercise 3.4

  A straight line y=ax+b in the plane can be represented by the pair(a,b) of real numbers.
  1. Declare a type StraightLine for straight lines.
  2. Declare functions t omirror straight lines around the x and y-axes.
  3. Declare a function to give a string representation for the equation of a straight line.
*)

// 1.
type straitLine = float * float


// 2.
let reflectX (line: straitLine) =
    let a, b = line
    (-a, -b)


let reflectY line : straitLine =
    let a, b = line
    (-a, b)


// 3."y = ax + b"

let getString (line: straitLine) =
    let a, b = line
    sprintf "y = %.2fx + %.2f" a b