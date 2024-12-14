// 3.10 Exceptions

module Section_03_10

(*
    Exceptions terminate the evaluation of functions when
    an error condition is detected.
*)

let solve (a, b, c) =
    let disc = b*b - 4.0 * a * c
    if disc < 0.0 || a = 0.0
    then  failwith "discriminant is negative or a=0.0"
    else 
        let sqrtD = sqrt disc
        ((-b + sqrtD) / (2.0 * a), (-b - sqrtD) / (2.0 * a))

(*
    It's possible to `catch` an exception using a 'try...with`
    expression
*)

let solveText eq =
    try
        string(solve eq)
    with
    | solve  -> "No solutions"

// val solveText: float * float * float -> string

// `solveText` returns the solution as text if it has a solution

let solution0 = solveText (1.0, 1.0, -2.0)
// val solution0: string = "(1, -2)"


// It returns "No solutions" if the equation has no solutions

let solution1 = solveText (1.0, 0.0, 1.0)
// val solution1: string = "No solutions"

// `failwith s` will raise the exception `Failure s` which can be
// caught.

// The function `mkQ`, for example, will call `failwith` in the case
// of a division by zero:

let mkQ =
    function
    | _, 0  -> failwith "Division by zero"
    | pr ->  (fst pr) / (snd pr)


let output =
    try
        mkQ(2, 0).ToString()
    with
    | Failure s -> s

// val output: string = "Division by zero"

// A 'try...with' expression has the form:
//      try e with match
// where 'e' us ab expression and 'match' is a construct or:
//      | pat1 -> e1
//      | pat2 -> e2
//      ...
//      | patn -> en
// with patterns `pat1 ... patn` and expressions `e1 ... en`
