# Type inference

 F# tries to determine the type of an expression, if it can't,
S an error is returned

```fsharp
let rec power = function
    | (x, 0) -> 1.0                 (* 1 *)
    | (x, n) -> x * power(x,n-1)    (* 2 *)

// val power: float * int -> float
```

The F# system deduces that `power` has the type: `float * int -> float`. We cans see how F# can infer the type by arguing as follows

1. The keyword `function` indicates that the type of power is a function of type $\tau \rightarrow \tau'$ for some type $\tau$ and $\tau`$

2. Since `power` is applied to a pair $(x,n)$ in the declaratio, the type $\tau$ must have the form $\tau_1 * \tau_2$ for some types $\tau_1$ and $\tau_2$

3. We have $\tau_2 = int$, since the pattern of the first clause is $(x,0), and 0 is type `int`.

4. We have that $\tau' = float$, since the expression for the function value is the first clase: `1.0` has type $float$.

5. We know that `power(x,n-1)` has the type $float$ since $\tau' - float$. Thus the overloaded operator symbol `*` in `x * power(x,n-1)` resolves to `float` multiplication ans `x` must be of type `float`.  We hence get $\tau_1 = float$.
