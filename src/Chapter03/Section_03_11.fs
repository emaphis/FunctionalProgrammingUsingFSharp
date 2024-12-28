// 3.11 Partial functions. The option type

module Section_03_11

(*
    A function 'f' is a 'partial' function a set 'A' if the domain of 'f' is a
    proper subset of 'A.'  Example: the factorial function is a partial function
    of the set of integers because it is undefined on negative integers.

    F# offers three ways of handling arguments where the function is undefined:

    1. The evaluation of the function does not terminate.

    2. The evaluation of the function is terminated by raising an exception.

    3. The evaluation of the function returns a special result.

    The third option can use the predefined 'option' type:
*)

//type 'a option = None | Some of 'a

(*
    Where 'None' is returned as the result of undefined function evaluations.
    and 'Some v' when the function evaluation has the value 'v'
*)

// The constructor 'Some' is polymorphic and can be applied to any value type

let res1 = Some false
// val res1 bool option = Some false

let res2 = Some [1; 2; 3]
//val res2: int list option = Some [1; 2; 3]

let res3 = Some []
//val res3: 'a list option

// The value `None` is a polymorphic value of 'a option.
let non1 = None
//val non1: 'a option


// the library function 'get' removes the 'Some' ie: `Option.get(Some n) = n from results.

let fun1 = Option.get
// val fun1: ('a option -> 'a)

let res4: bool = Option.get(res1)
// val res4: bool = false

let res5 = Option.get(Some (1, "a"))
// val res5: int * string = (1, "a")

let res6 = Option.get(Some 1)
// val res6: int = 1

//let res7 = Option.get None + 1
// System.ArgumentException: The option value was None


// Redefined 'fact' function

let rec fact n =
 if n = 0 then 1
 else n * fact(n - 1) 

let optFact n =
    if n < 0 then None
    else Some(fact n)

// val optFact: n: int -> int option

// now 'optFact' always returns a value given an integer

let res8 = optFact 5
// val res8: int option = Some 120

let res9 = optFact -2
// val res9: int option = None


// optFact assume the existence of 'fact' but 'optFact' can fe defined
// independently

let rec optFact' = function
    | 0     -> Some 1
    | n when n > 0 -> Some(n * Option.get(optFact'(n-1)))
    | _     -> None;

// val optFact': _arg1: int -> int option


let res10 = optFact' 5
// val res10: int option = Some 120

let res11 = optFact' -2
// val res11: int option = None
