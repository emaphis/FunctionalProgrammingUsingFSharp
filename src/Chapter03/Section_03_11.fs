// 3.11 Partial functions. The option type

module Section_03_11

(*
    A function 'f' is a 'partial' function a set 'A' if the domain of 'f' is a
    proper subset of 'A.'  So the factorial function is a partial function
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

// the library function 'get' removes the 'Some' from the failure.

let fun1 = Option.get
// val fun1: ('a option -> 'a)

let res2: bool = Option.get(res1)
// val res2: bool = false

let res3 = Option.get(Some (1, "a"))
// val res3: int * string = (1, "a")

let res4 = Option.get(Some 1)
// val res4: int = 1

//let res5 = Option.get None + 1
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

let res6 = optFact 5
// val res6: int option = Some 120

let res7 = optFact -2
// val res7: int option = None


// optFact assume the existence of 'fact' but 'optFact' can fe defined
// independently

let rec optFact' = function
    | 0     -> Some 1
    | n when n > 0 -> Some(n * Option.get(optFact'(n-1)))
    | _     -> None;

// val optFact': _arg1: int -> int option


let res8 = optFact' 5
// val res8: int option = Some 120

let res9 = optFact' -2
// val res9: int option = None
