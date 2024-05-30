// 1.3 Anonymous functions. Function expressions

module Section03

(*
    A function can be created in F# without getting any name. This is done by evaluating a function expression,
    that is an expression where the value is a function.
*)

// cr is set to the value of a lambda function
let cr = fun r -> System.Math.PI * r * r
// val cr: r: float -> float

let area1 = cr 2.0
// val area1: float = 12.56637061

let area2 = (fun r -> System.Math.PI * r * r) 2.0

let circleArea = fun r -> System.Math.PI * r * r

// Function Expressionss with patterns

// It is often convenient to define a function in terms of a number of cases.

let daysOfMonth =
    function
    | 2 -> 28 // February
    | 4|6|9|11 -> 30 // April, June, September, November
    | _ -> 31 // All other months

let days1 = daysOfMonth 3
// 31

let days = daysOfMonth 9
// 30
