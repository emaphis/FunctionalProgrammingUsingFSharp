module Chapter01.Exercise_02

(*
    1.2 Declare a function `h: float * float -> float`, where `h(x, y) = sqrt(x^2 + y^2)`.
        Hint: Use the function System.Math.Sqrt.
*)

/// Calculate the Sqrt of the squars of two given integers.
let h(x, y) =
    System.Math.Sqrt(x * x + y * y)

// val h: x: float * y: float -> float
