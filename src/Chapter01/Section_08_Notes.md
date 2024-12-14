# Section 1.8 Euclid's algorithm

The GCD theorem of Euclid: For any integers $m, n$ there exists an integer $gcd(m, n)$ such that $gcd(m, n) \geq 0$, and such that the common divisors of $m$ and $n$ are
precisely the divisors of $gcd(m, n)$

In $n \neq 0$ or $ n \neq 0$ then $gcd(m,n)$ is the greatest common divisor of $m$ and $n$. For $m = 0$ and $n = 0$ we have $gcd(0,0)$, as the common divisors as $0$ and $0$ are the divisors of $0$, but $0$ and $0$ have no greatest common divisor as any number is a divisor of $0$.

## Division with remainder, The `/` and `%` operators

Euclid's algorithm uses integer division. Let $m$ and $n$ be integers with $m \neq 0$. An identity with integers $q$ and $r$ is:

$$
n = q \cdot m + r
$$

is then called a division with quotient $q$ and reminder $r$. There are infinite many possible remainders with corresponding quotients $q$.

$$
..., n - 3 \cdot |m|, n - 2 \cdot |m|, n - |m|, n, n + |m|, n + 2 · |m|, n + 3 · |m|, ...
$$

If follows that there are two possibilities concerning remainders $r$ with $-|m| < r < |m|$:

1. The integer $0$ is a remainder and any other remainder $r$ satisfies $|r| \geq |m|$.

2. There are two remainders $r_{neg}$ and $r_{pos}$ such that $−|m| < r_{neg} < 0 < r_{pos} < |m|$.

The F# operators `/` and `%` are defined for $(m \new 0) such that:

$$
n = (n / m) \cdot m + (n \space \% \space m)\\
|n \space \% \space m| < |m|\\
m \space \% \space m \geq 0 \text{ when } n \geq 0\\
m \space \% \space m \leq 0 \text{ when } n < 0
$$

## F# definition Euclid’s algorithm

```fsharp
let rec gcd = function
| (0, n) -> n
| (m, n) -> gcd(n % m, m)

// val gcd : int * int -> int
```
