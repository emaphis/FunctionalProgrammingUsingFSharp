module Chapter03.Section_03_03

// 3.3  Example: Geometric vectors

(*
    A cartesian coordinate representation of a vector in the plain represented by `float * float`
    We will have functions:
        Vector addition:            (x1, y1) + (x2, y2) =   (x1 + x2, y1 + y2)
        Vector reversal:            −(x, y)             =   (−x, −y)
        Vector subtraction:         (x1, y1) − (x2, y2) =   (x1 − x2, y1 − y2)
                                                        =   (x1, y1) + −(x2, y2)

        Multiplication by a scalar: λ (x1, y1)          =   (λx1, λy1)
        Dot product:                (x1, y1) * (x2, y2) =   x1 * x2 + y1 * y2
        Norm (length):              |(x1, y1)|          =   sqrt(x^2 + y^2)
*)

// We must give new operators new names so the old operators meanings are over written.

// The prefix operator for vector reversal is declared by (cf. Section 2.9):

/// Vector reversal.
let (~-.) (x: float, y: float) = (-x, -y)
// val (~-.) : x: float * y: float -> float * float

// infix operators:

/// Vector addition
let (+.) (x1, y1) (x2, y2) = (x1+x2, y1+y2): float * float
// val (+.) : x1: float * y1: float -> x2: float * y2: float -> float * float

/// Vector subtraction
let (-.) v1  v2 = v1 +. -. v2
// val (-.) : float * float -> float * float -> float * float

/// Multiplication by a scalar
let ( *.) x (x1, y1) = (x*x1, x*y1) : float * float
// val ( *. ) : x: float -> x1: float * y1: float -> float * float

/// Dot product
let (&.) (x1,y1) (x2,y2) = x1*x2 + y1*y2 : float
// al (&.) : x1: float * y1: float -> x2: float * y2: float -> float

/// Norm
let norm(x1:float, y1:float) = sqrt(x1*x1 + y1*y1)
// al norm: x1: float * y1: float -> float

// Examples

let a = (1.0, -2.0)
let b = (3.0, 4.0)
// val a: float * float = (1.0, -2.0)
// val b: float * float = (3.0, 4.0)

let c = 2.0 *. a -. b
// val c: float * float = (-1.0, -8.0)

let d = c &. a
// val d: float = 15.0

let e = norm b
// val e: float = 5.0
