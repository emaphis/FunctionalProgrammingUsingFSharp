// Exercise 2.13

(*
    Exercise 2.12

    The functions curry and uncurry of types
    
        curry : (’a * ’b -> ’c) -> ’a -> ’b -> ’c
        uncurry : (’a -> ’b -> ’c) -> ’a * ’b -> ’c
    
    are defined in the following way:
    
    curry f is the function g where g x is the function h where h y = f(x, y).
    
    uncurry g is the function f where f(x, y) is the value h y for the function h = g x.
    
    Write declarations of curry and uncurry.
*)

let curry f a b = f(a, b)
// val curry: f: ('a * 'b -> 'c) -> a: 'a -> b: 'b -> 'c

let uncurry f (a,b) = f a b
// val uncurry: f: ('a -> 'b -> 'c) -> a: 'a * b: 'b -> 'c



let add (a, b) = a + b
// val add: a: int * b: int -> int

add(3, 4) = 7


let currAdd = curry add
// val currAdd: (int -> int -> int)

currAdd 3 4 = 7


let uncurrAdd = uncurry currAdd
// val uncurrAdd: (int * int -> int)

uncurrAdd(3, 4) = 7
