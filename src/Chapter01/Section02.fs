// Section 1.2 Simple function declarations

module Section02

(*
    We now consider the declaration of functions. One can name a function, just as one can
    name an integer constant.
*)

let pi = System.Math.PI
// val pi: float = 3.141592654

// Declaration of a function
let circleArea1 r = System.Math.PI * r * r
//val circleArea1: r: float -> float

let area1 = circleArea1 1.0
// val area1: float = 3.141592654

let area2 = circleArea1 (2.0)
// val area2: float = 12.56637061

// Comments

(*
    Area of a circle with radius r
    Multiline comments
*)

// Area of circle with radius r  - for inline comments

// Documentations comments

/// Area of circle with radius r
let circleArea r = System.Math.PI * r * r
