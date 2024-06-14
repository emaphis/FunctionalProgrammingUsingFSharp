// 3.5 Quadratic equation

module Chapter03.QuadraticEquation

// The declaration of solve with error handling and locally defined functions and constangs.

let solve (a, b, c) =
    let disc = b*b - 4.0 * a * c
    if disc < 0.0 || a = 0.0
    then  failwith "discriminant is negative or a=0.0"
    else 
        let sqrtD = sqrt disc
        ((-b + sqrtD) / (2.0 * a), (-b - sqrtD) / (2.0 * a))

// val solve: a: float * b: float * c: float -> float * float


let sln0 = solve(1.0, 0.0, 1.0)
// FSI_0004+Solve: Solve

let sln1 = solve(1.0, 1.0, -2.0)
// val sln1: float * float = (1.0, -2.0)

let sln2 = solve(2.0, 8.0, 8.0)
// val sln2: float * float = (-2.0, -2.0)
