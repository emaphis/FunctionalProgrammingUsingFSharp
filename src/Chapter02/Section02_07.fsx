// 2.7 Functions are first-class citizens

// Gentle introduction to this concept, which also is known as higher-order funct

// The value of a function can be a function:

(+)
// val it: (int -> int -> int) = <fun:it@7-1>

// The type operator `->` associates to the right:
// Applying (+) to one integer returns a function of type
// `(+) n: int -> int`

let plusThree = (+) 3
// val plusThree: (int -> int)

let num1 = plusThree 5
// val num1: int = 8

let num2 = plusThree -7
// val num2: int = -4

// The sum of two integers m and n can be computed as ((+) m) n:

let num3 = (+) 3 5
// val num3: int = 8


// The argument of a function can be a function:

// (f ◦ g)(x) = f(g(x)).
// so: If f : A → B and g : C → A, then f ◦ g : C → B

// For example, if f(y) = y + 3 and g(x) = x2, then (f ◦ g)(z) = z2 + 3.

let f = fun y -> y + 3
// val f: y: int -> int

let g = fun x -> x*x
// val g: x: int -> int

let h = f << g
// val h: (int -> int)

let num4 = h 4
// val num4: int = 19

// Computing with expressions instead of definitions:

let num5 = ((fun y -> y+3) << (fun x -> x*x)) 4
// al num5: int = 19


// Declaration of higher-order functions

// Example:
// Suppose that we have a cube with side length `s`, containing a liquid with density `ρ`. The
// weight of the liquid is then given by `ρ · s^3`. If the unit of measure of `ρ` is `kg/m^3`
// and the unit of measure of `s` is `m` then the unit of measure of the weight will be `kg`.

let weight ro = fun x -> ro * x ** 3.0
// val weight: ro: float -> x: float -> float

// We can make partial evaluations of the function weight to define functions for computing the
// weight of a cube of either water or methanol (having the densities `1000kg/m^3` and `786.5kg/m^3

let waterWeight = weight 1000.0
// val waterWeight: (float -> float)

let weight1 = waterWeight 1.0
//val weight1: float = 1000.0

let weight2 = waterWeight 2.0
// val weight2: float = 8000.0

let methanolWeight = weight 786.5
// val methanolWeight: (float -> float

let weight3 = methanolWeight 1.0
// val weight3: float = 786.5

let weight4 = methanolWeight 2.0
// val weight3: float = 6292.0


1