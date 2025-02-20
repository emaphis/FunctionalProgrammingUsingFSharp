﻿# Section 1.5 Pairs

Use for pairs can be demonstrated by the `power` function:

$$
x^n = x \cdot x \cdot ... \cdot x \quad n\space \text{occurrences of}\space x,\space \text{where} \space n \geq 0
$$

where $x$ is a real number and $n$ is a natural number.

The under-brace part of the express below for $x^n$ is the expression of $x^{n-1}$:

$$
x^n = x\cdot\underbrace{x \cdot ... \cdot x}_{x^{n-1}} \quad n \text{ occurrences of } x, \text{ when } n > 0
$$

Using the convention: $x^n=1$, the function can be characterized by the recursion formula:

$$
\begin{align}
x&^0 = 1 \\
x&^n = x \cdot x^{n-1} \quad \text{ for } n > 0
\end{align}
$$

In mathematics $x^n$ is a function of two variables $x$ and $n$, but it can be represented by pairs in F#:

$$
\boxed{\text{If } a_1 \text{ and } a_2 \text{ are values of types } \tau_1 \text{ and } \tau_2 \text{ then } (a_1,a_2) \text{ is a value of type } \tau_1 * \tau_2}
$$

In F#

```fsharp
let pr = (2.0,3);;
val pr: float * int = (2.0, 3)
```

A pair is a special case of Tuples which will be treated in 3.1

F# Definition of the `power` function using pairs

```fsharp
let rec power = function
   | (x,0) -> 1.0                // (1)
   | (x,n) -> x * power(x,n-1)   // (2)
// val power: float * int -> float w
```

An evaluation of `pr`

```fsharp
> power pr;;
val it: float = 8.0
```

A pair:

```fsharp
let a = (4.0, 2)
// val a: float * int = (4.0, 2)
```

evaluation:

```fsharp
    power a
    -> power (4.0, 2)               // Sustitution
    -> 4.0 * power(4.0,2-1)         // Clause 2, x is 4.0, n is 2)
    -> 4.0 * power(4.0,1)
    -> 4.0 * (4.0 * power(4.0,1-1)) // Clause 2, x is 4.0, n is 1)
    -> 4.0 * (4.0 * power(4.0,0))
    -> 4.0 * (4.0 * 1.0)            // Clause 1, x is 4.0
    -> 16.0
```

## Notes on pattern matching

The order of clauses is significant: specific clauses should be ordered before general causes.
