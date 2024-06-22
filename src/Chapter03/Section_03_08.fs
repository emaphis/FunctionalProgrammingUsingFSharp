// 3.8 Tagged values. Constructors
module Section_03_08

(*
    Tagged values are used to group together related types under one type.

    As an example circles can be defined by radius 'r', squares by side 'a', and triangles
    by side 'a', 'b' and 'c' but can be treated as the same type 'shape'.
    The different types of shapes can be represented by `tags` 'Circle', 'Square`
    'Triangle' depending on the type of 'Shape'

    F# tagged values are declared by a 'type' declaration:
*)

type Shape =
    | Circle of float
    | Square of float
    | Triangle of float * float * float

(*
    Constructors and values

    'Circle', 'Square' and 'Triangle' tagged values are bound constructors
    for type 'Shape. 'Circle' is a value constructor of type `float -> Shapre` whece
    Shapre is a subtype 'Circle' of the 'Shape' type.
*)

let shape1 = Circle 1.2
// val shape1: Shape = Circle 1.2

// Notice that 'Circle 1.2' is a concrete data type and not evaluated further.

let shape2 = Square 3.4
// val shape2: Shape = Square 3.4

let shape3 = Circle (8.0 - 2.0 * 3.4)
// al shape2: Shape = Circle 1.2


(*
    Equality and ordering

    Equality and ordering are defined for taggeg values if they are
    defined for their components.

    Two tagged values are equal if they have the same constructor and
    their components are equal.
*)

let equal1 = Circle 1.2 = Circle (1.0 + 0.2)
// val equal1: bool = true

let equal2 = Circle 1.2 = Square 1.2
// val equal2: bool = false


// Constructors in patterns

let area' = function
    | Circle r   -> System.Math.PI * r * r
    | Square a   -> a * a
    | Triangle (a, b ,c) ->
        let s = (a + b + c) / 2.0
        sqrt(s * (s - a) * (s - b) * (s - c))

// val area: _arg1: Shape -> float

// Pattern matching treats constructors diefferently for other identifiers:

    // A constructor matches itself only in a pattern match
    // while other identifiers match any value

// Example:  'Circle 1.2' will match the pattern 'Circle r' but not other 
//  but not the other patterns in the function declaration.
//  the identifier `r` is bound to the value `1.2` and the expression
// 'Math.PI * r * r' is evaluated to a result

let area1 = area' (Circle 1.2)
// ->  area1 = (Math.PI * r * r, [r -> 1.2])
// ->  area1 = (Math.PI * 1.2 * 1.2)
// ->  val area1: float = 4.523893421

let area2 = area' (Triangle (3.0, 4.0, 5.0))
// -> area2 = (let s = (a + b + c) / 2.0), [a -> 3.0, b -> 4.0, c -> 5.0])
// -> val area2: float = 6.0


// Invariant for the representation of shapes

// Not all values of shapes represent geometric shapes, ie: `Cirlce -1.0` and
//  and 'Square -2.0' are invalid shapes.

let shape4 = Triangle (3.0, 4.0, 7.5)
// is not a valid shape as 7.5 > 3.0 + 4.0

let isShape = function
    | Circle r      -> r > 0.0
    | Square a      -> a > 0.0
    | Triangle (a, b, c) ->
        a > 0.0 && b > 0.0 && c > 0.0
        && a < b + c && b < a + c && c < a + b


let area x =
    if not (isShape x)
    then failwith "not a legal shape"
    else
        match x with
        | Circle r   -> System.Math.PI * r * r
        | Square a   -> a * a
        | Triangle (a, b ,c) ->
            let s = (a + b + c) / 2.0
            sqrt(s * (s - a) * (s - b) * (s - c))


let area3 = area (Triangle(3.0,4.0,5.0))
// val area3: float = 6.0

let area4 = area (Triangle(3.0,4.0,7.5))
// System.Exception: not a legal shape
