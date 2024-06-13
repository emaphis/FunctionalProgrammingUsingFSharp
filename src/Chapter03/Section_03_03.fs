// 3.3  Example: Geometric vectors

(*
    A cartesian coordinate representation of a vector in the plain represented by `float * float`
    We will have functions:
        Vector addition:            (x1, y1) + (x2, y2) =   (x1 + x2, y1 + y2)
        Vector reversal:            −(x, y)             =   (−x, −y)
        Vector subtraction:         (x1, y1) − (x2, y2) =   (x1 − x2, y1 − y2)
                                                        =   (x1, y1) + −(x2, y2)

        Multiplication by a scalar: λ (x1, y1)          =   (λx1, λy1)
        Dot product:                (x1, y1) * (x2, y2) =   x1x2 + y1y2
        Norm (length):              |(x1, y1)|          =   sqrt(x^2 + y^2)
*)

// The prefix operator for vector reversal is declared by (cf. Section 2.9):
let (~-.) (x: float, y: float) = (-x, -y)
// val (~-.) : x: float * y: float -> float * float


