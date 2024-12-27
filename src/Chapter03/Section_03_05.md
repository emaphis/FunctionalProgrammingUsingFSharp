# 3.5 Example: Quadratic equations

We will write code to solve for the roots of quadratic equations

$$
ax^2 + bx + c = 0
$$

of real coefficients `a, b, c`.

The equation has no solution in real numbers if the `discriminant` $b^2 - 4ac$ is negative. if  $b^2 - 4ac \geq 0$ and $a \neq 0$, then the equation as solutions $x_1$ and $x_2$.

So:

$$
x_1 = \frac{-b + \sqrt{b^2 - 4ac}}{2a} \quad \text{ and } \quad x_2 = \frac{-b - \sqrt{b^2 - 4ac}}{2a}
$$

Note that $x_1 = x_2$  if  $b^2 - 4ac = 0$.

We will represent the quadratic equation by the triple $(a,b,c)$ of real numbers and the solutions $x_1$ and $x_2$ by the pair $(x_1, x_2)$ of real numbers. In F#:

```fsharp
type Equation = float * float * float
type Solution = float * float
```

A function type:

```fsharp
type Solve: Equation -> Solution
```

for computing the solutions of the given equation represented as a triple.

See: `QuadraticEquation.fs` for code of this example.

## Error handling

Function `solve` must produce and error message when $b^2 - 4ac < 0$ or $a = 0$. We can signal errors using an `exception` through and `exception declaration`.

```fsharp
exception Solver
exception Solve
```

The declaration of solve

```fsharp
let solve (a, b, c) =
    if b*b - 4.0 * a * c < 0.0 || a = 0.0 then raise Solve
    else
        ((-b + sqrt(b*b - 4.0 * a * c)) / (2.0 * a),
         (-b - sqrt(b*b - 4.0 * a * c)) / (2.0 * a))

// val solve: a: float * b: float * c: float -> float * float         
```

Some examples

```fsharp
// solve(1.0, 0.0, 1.0)
// FSI_0004+Solve: Solve

let sln1 = solve(1.0, 1.0, -2.0)
// val sln1: float * float = (1.0, -2.0)

let sln2 = solve(2.0, 8.0, 8.0)
// val sln2: float * float = (-2.0, -2.0)
```

Using `failwith`

```fsharp
let solve (a, b, c) =
    if b*b - 4.0 * a * c < 0.0 || a = 0.0
    then failwith "discriminant is negative or a=0.0"
    else
        ((-b + sqrt(b*b - 4.0 * a * c)) / (2.0 * a),
         (-b - sqrt(b*b - 4.0 * a * c)) / (2.0 * a))

// val solve: a: float * b: float * c: float -> float * float

> solve(1.0, 0.0, 1.0);;
System.Exception: discriminant is negative or a=0.0
```
