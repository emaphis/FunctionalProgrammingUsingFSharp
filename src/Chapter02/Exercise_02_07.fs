module Chapter02.Exercise_02_07


(*
    Exercise 2.7
    1. Declare the F# function test: int * int * int -> bool. The value of test(a, b, c),
       for a ≤ b, is the truth value of

                notDivisible(a, c)
            and notDivisible(a + 1, c)
            ...
            and notDivisible(b, c)

    2. Declare an F# function prime: int -> bool, where prime(n) = true, if and only if n
       is a prime number.

    3. Declare an F# function nextPrime: int -> int, where nextPrime(n) is the smallest
       prime number > n.
*)

/// True if and only if `d` is not a divisor of `n`.
let notDivisible(d, n) = n % d <> 0

// 1.

/// Returns `true` if c is not divisible by any of the integers
/// in the range a -> b inclusive
let rec testRange(a, b, c) =
    if a > b then true  // base case
    else notDivisible(a, c) && testRange(a+1, b, c)

// val testRange: a: int * b: int * c: int -> bool

// 2.

/// Returns `true` if the given integer is prime.
let prime(n) = testRange(2, n-1, n)

// val prime: n: int -> bool


// 3.

/// Find the next prime after the given number
let rec nextPrime(n) =
    if prime(n+1) then n+1
    else nextPrime(n+1)

// val nextPrime: n: int -> int
