# Section 1.7 Bindings and environments

The notions of binding and environment are used
to explain that entities are bound by identifiers.

Executing a declaration `let x = e`, causes the identifier `x` to be bound to the values of the expression $e$:

```fsharp
let a = 3
// val a : int = 3
```

causes the identifier `a` to be bound to `3`. This binding is denoted by $a \mapsto 3$.

Execution of further declarations gives extra bindings:

```fsharp
let b = 7.0;;
// val b : float = 7.0
```

creates a new binding $b \mapsto 7.0$.

A collection of bindings is called an `environment`. The $env_1$ is obtained from the execution of the two declarations.

$$
env_1 =
\begin{vmatrix}
a \mapsto 3 \\
\space \space b \mapsto 7.0
\end{vmatrix}
$$

The execution of:

```fsharp
let c = (2, 8)
let circleArea r = System.Math.PI * r * r
```

add the bindings for `c` and `circleArea` to the new environment:

$$
env_2 =
\begin{vmatrix}
a \mapsto& 3\\
b \mapsto& 7.0\\
c \mapsto& (2,8)\\
circleArea \mapsto& "circle area function"
\end{vmatrix}
$$
