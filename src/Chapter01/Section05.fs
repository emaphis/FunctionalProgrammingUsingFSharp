namespace Chapter01

// Section 1.5 Pairs

module Section05 =
    
    // example pair
    let a = (2.0, 3)
    // val a: float * int = (2.0, 3)

    let (x,y) = a
    // val y: int = 3
    // val x: float = 2.0

    /// Calculates the power function given a `float * int`
    let rec power = function
        | (x,0) -> 1.0
        | (x,n) -> x * power (x, n-1)

    // val power: float * int -> float
    
    let num1 = power a
    // val num1: float = 8.0

    let num2 = power (4.0,2)
    // val num2: float = 16.0