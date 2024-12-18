module Chapter02.Exercise_02_06_07

// Exercises 6, 7

(*
    Exercise 2.6
    Declare the F# function `notDivisible: int * int -> bool` where
   
        notDivisible(d, n) is true if and only if `d` is not a divisor of `n`.

    For example 'notDivisible(2,5)' is true, and 'notDivisible(3,9)' is fal
*)

/// True if and only if `d` is not a divisor of `n`.

let notDivisible(d, n) = not (n % d = 0)
// val notDivisible: d: int * n: int -> bool


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
    let nextN = n + 1
    if prime nextN then nextN
    else nextPrime nextN

// val nextPrime: n: int -> int


// Bonus:


/// Compute the first 'num' primes
let nPrimes num =
    let rec loop (num, acc) =
        match num with
        | 0 -> List.rev acc
        | num ->
                let nPrime = nextPrime (List.head acc)
                loop ((num - 1), (nPrime :: acc))

    loop (num, [1])
