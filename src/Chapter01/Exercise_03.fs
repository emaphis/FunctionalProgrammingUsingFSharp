module Chapter01.Exercise_03

(*
   1.3 Write function expressions corresponding to the functions g and h in the exercises 1.1 and 1.2.
*)

/// Adds 4 to a given integer
let g =
    fun n -> n + 4

// val g: n: int -> int


/// Calculate the Sqrt of the squares of two given integers.
let h =
    fun(x, y) ->
        System.Math.Sqrt(x * x + y * y)

// val h: x: float * y: float -> float
