namespace Chapter01

// 1.8 Euclid's algorithm

module Section08 =

    /// Calculate the Greatest Common Divisor of two given integers
    let rec gcd = function
        | (0, n) -> n
        | (m, n) -> gcd(n % m, m)

    // val gcd: int * int -> int

    let num1 = gcd(12, 27)
    // val num1: int = 3

    let num2 = gcd(36, 116)
    // val num2: int = 4