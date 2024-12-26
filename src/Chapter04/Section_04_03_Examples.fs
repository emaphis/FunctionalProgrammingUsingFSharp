module Chapter04.Section_04_03_Examples

// Example functions from sections 3, 4 and 5

// 4.3 Typical recursions over lists

// Function declarations with two clauses

// We define the value of the “empty” sum, that is, suml [],to be 0, and we arrive at a recursive
// function declaration with two clauses:

let rec suml = function
    | []    -> 0  // base case
    | x::xs -> x + suml xs;;
//val suml: _arg1: int list -> int

let sm1 = suml [1; 2];;
//val sm1: int = 3


// Function declarations with several clauses

// altsum has three different arguments.

// 1. empty list: altsum[] =0
// 2. list with one element: altsum[x0] = x0
// 3. list with two or more elements
//      altsum[x0;x1;x2;...;xn−1] = x0- x1 + altsum[x2;...;xn−1]

let rec altsum = function
    | []         -> 0
    | [x]        -> x
    | x0::x1::xs -> x0 - x1 + altsum xs

// val altsum: _arg1: int list -> int

let sm2 = altsum [2; -1; 3];;
//val sm2: int = 6


// Layered patterns

// succPairs

let rec succPairs' = function
    | x0 :: x1 :: xs -> (x0, x1) :: succPairs' (x1 :: xs)
    | _              -> []

//val succPairs': _arg1: 'a list -> ('a * 'a) list

// A pattern x0::(x1::_ as xs) containing a layered sub-pattern
//  x1::_ as xs

let rec succPairs = function
    | x0 :: (x1 :: _ as xs) -> (x0, x1) :: succPairs xs
    | _                     -> []

//val succPairs: _arg1: 'a list -> ('a * 'a) list

let lst1 = succPairs [1; 2; 3]
// al lst1: (int * int) list = [(1, 2); (2, 3)]



// Pattern matching on result of recursive call

// the use of pattern matching to split the result of a recursive
// call into components.

let rec sumProd = function
    | []        -> (0, 1)
    | x::rest   ->
        let rSum, rProd = sumProd rest
        (x+rSum, x * rProd)

// val sumProd: _arg1: int list -> int * int

let pair0 = sumProd [2; 5];;
//val pair0: int * int = (7, 10)


// unzip

let rec unzip = function
    | []             -> ([], [])
    | (x, y) :: rest ->
        let xs, ys = unzip rest
        (x::xs, y::ys)

// val unzip: _arg1: ('a * 'b) list -> 'a list * 'b list

let lst2 = unzip [(1, "a"); (2, "b")]
//val lst2: int list * string list = ([1; 2], ["a"; "b"])


// Pattern matching on pairs of lists

let rec mix = function
    | x::xs, y::ys -> x::y::(mix (xs, ys))
    | [], []          -> []
    | _                 -> failwith "mix parameter error"

// val mix: 'a list * 'a list -> 'a list

let lst3 = mix ([1;2;3],[4;5;6]);;
//val lst3: int list = [1; 4; 2; 5; 3; 6]


// 4.4 Polymorphism

// List membership

let rec isMember x = function
    | y::ys -> x=y || (isMember x ys)
    | []        -> false;

//val isMember: x: 'a -> _arg1: 'a list -> bool when 'a: equality

// Append and reverse. Two built-in functions

let rec ( @. ) xs ys =
    match xs with
    | []        -> ys
    | x::xs' -> x::(xs' @. ys)

// val (@) : xs: 'a list -> ys: 'a list -> 'a list

let lst4 = [1;2] @. [3;4];;
//val lst4: int list = [1; 2; 3; 4]

let lst5 = [[1];[2;3]] @. [[4]];;
//val lst5: int list list = [[1]; [2; 3]; [4]]

let lst6 = [1] @. 2 :: [3];;
//val lst6: int list = [1; 2; 3]

let lst7 = 1 :: [2] @. [3];;
//val lst7: int list = [1; 2; 3]


// Reverse

let rec naiveRev xls =
    match xls with
    | []    -> []
    | x::xs -> (naiveRev xs) @ [x]

// val naiveRev: xls: 'a list -> 'a list

let lst8 = naiveRev [1;2;3];;
//val lst8: int list = [3; 2; 1]
