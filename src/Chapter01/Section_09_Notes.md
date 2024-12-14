
# 1.9 Evaluations with environments

The creation of temporary environments for recursive programs.

The GCD program:

```fsharp
let rec gcd = function
    | (0,n) -> n
    | (m,n) -> gcd(n % m,m);;

val gcd : int * int -> int
```

Contains two clauses: One pattern $(0, 1)$ which matches the expression $n$ and another with the pattern $(m, n)$ with the expression $gcd(n \% m, m)$. So the expression $gcd(x, y)$ has two corresponding clauses:

Clause 1: $gcd(0, y)$: The argument $(0, y)$ matches the pattern $(0, n)$ in the first clause giving the binding $n \mapsto y$, and the system evaluates the corresponding right hand expression using the binding:

$$
gcd(y, 0) \leadsto (n, [n \mapsto y]) \leadsto y
$$

Clause 2: $gcd(x, y)$ with $x \neq 0$. The argument $(x, y)$ matches the pattern $(m, n)$, the second clause given the bindings $m \mapsto x, n \mapsto y$, which will evaluate the corresponding right-hand side expression $gcd(n \% m, m)$ using these bindings:

$$
gcd(x, y) \leadsto gcd(n \% m,m), [m \leadsto x, n \leadsto y] \leadsto ...
$$

Given the example expression $gcd(36, 116)$. The value $(36, 116)$ does not match the pattern $(0, n)$ but matches the second clause:

$$
gcd(36, 116) \leadsto (gcd(n \% m, m), [m \mapsto 36, n \mapsto 116])
$$

The next evaluation step:

$$
\begin{align*}
\space &(gcd(n \%m, n), [m \mapsto 36, n \mapsto 116]) \\
\leadsto \space &gcd(116 \% 36, 36) \\
\leadsto \space &gcd(8, 36)
\end{align*}
$$

Continued:

$$
\begin{align*}
 \space &gcd(8, 36) \\
\leadsto \space &(gcd(n \%m, n), [m \mapsto 8, n \mapsto 36]) \\
\leadsto \space &gcd(36 \% 8, 8) \\
\leadsto \space &gcd(4, 8)
\end{align*}
$$

Last:

$$
\begin{align*}
 \space &gcd(4, 8) \\
\leadsto \space &(gcd(n \%m, n), [m \mapsto 4, n \mapsto 8]) \\
\leadsto \space &... \\
\leadsto \space &gcd(0, 4) \\
\leadsto \space &(n, [n \mapsto 4]) \\
\leadsto \space &4
\end{align*}
$$
