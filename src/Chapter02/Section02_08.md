# 2.8 Closures

A `closure` give the means of explaining a value thas is a function. A closure is a triple:

$$
(x, exp, env)
$$

Given:

```fsharp
let weight ro = fun x -> ro * x ** 3.0
// val weight: ro: float -> x: float -> float

let methanolWeight = weight 786.5
// val methanolWeight: (float -> float)
```

The resulting closure is:
$$
\left(s, ro \text{ * } s \text{ ** } 3.0, \left[
    \begin{align*}
    ro& \mapsto 786.5 \\
    *& \mapsto \text{"the product function"} \\
    **& \mapsto \text{"the power function"}
    \end{align*}
    \right]\right)
$$

Note that a closure is a `value` in F# – functions are first-class citizens.

Another example

```fsharp
let pi = System.Math.PI
let circleArea r = pi * r * r
//val circleArea : float -> float
```

These declarations bind the identifier `pi` to a `float` value and `circleArea` to a closure:

$$
\begin{align*}
pi& \mapsto 3.14159 ...\\
circleArea& \mapsto (r, pi * r * r, [pi \mapsto 3.14159 ...])
\end{align*}
$$

A new binding of `pi` doesn not effect the meaning of the `circleArea`function since closures in F# are static:

```fsharp
let pi = 0
circleArea 1.0
val it : float = 3.141592654
```

This property is called static binding.
