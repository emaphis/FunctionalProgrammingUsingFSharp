module Chapter03.Exercise_03_05

type Equation = float * float * float

type Solution =
    | TwoRoots  of float * float
    | OneRoot   of float
    | NoRoot



let solve ((a, b, c): Equation) =
    let disc = b*b - 4.0 * a * c
    if disc < 0.0 || a = 0.0
    then  NoRoot
    else 
        let sqrtD = sqrt disc
        let root1 = (-b + sqrtD) / (2.0 * a)
        if disc = 0.00
        then OneRoot root1 //(-b / (2.0 * a))
        else
            let root2 = (-b - sqrtD) / (2.0 * a)
            TwoRoots (root1, root2)

// val solve: a: float * b: float * c: float -> Solution


let sln0 = solve (1.0, 0.0, 1.0) = NoRoot

let bl1 = solve (0, 5, -3) = NoRoot

let sln1 = solve (1.0, 1.0, -2.0) = TwoRoots (1.0, -2.0)

let sln2 = solve (2.0, 8.0, 8.0) = OneRoot -2.0
// val sln2: float * float = (-2.0, -2.0)

let bl2 = solve (1.0, 0.0, -25.0)  = TwoRoots (5.0, -5.0)

let sln3 = solve (2.0, 8.0, 8.0)
