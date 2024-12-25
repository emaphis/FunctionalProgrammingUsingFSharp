# 4.5 The value restrictions on polymorphic expressions

F# has restrictions on polymorphic expression to ensure type correctness in all situations.

This restriction is based on the concept of `value expressions` A value expression is an expression that cannot be reduced further by evaluation. The following are value expressions.

$ \qquad [\space] \qquad Some \space [\space] \qquad (5,\space [\space]) \qquad (fun \space x -> [8]) $

while

$ \qquad List.rev \space [\space] \qquad [\space] \space @ \space[\space] $

arw not value expressions as they can be further evaluated. A function expression is considered a value expression because it can be further evaluated unless it's applied to arguments.

The restriction applies to the expression $exp$ in declarations

$ \qquad let \space id \space = \space exp$

and states the following

$$
\begin{align*}
\boxed {
\text {At the top level, polymorphic expressions are allowed only if they are value expressions } \space \newline
\text {Polymorphic expressions con be used freely for intermediate results}
 }
 \end{align*}
$$

F# allows `values` of polymorphic types, such as empty list $[\space]$, the pair $(5, [\space])$ or the function $(fun \space x \space [x])$

```fsharp
let z = [];;
val z: 'a list

> (5,[[]]);;
val it: int * 'a list list

> let p = (fun x-> [x]);;
val p: x: 'a -> 'a list
```

But the following is refused at the top level:

```fsharp
> List.rev [];;
//  error FS0030: Value restriction: The value 'it' has an inferred generic type
//    val it: '_a list
```

This can be restated as:

* All monomorphic expressions are OK, even non-value expressions,

* All value expressions are OK, even polymorphic ones, and

* at top-level, polymorphic non-value expressions are forbidden,

where the type of `monomorphic expressions` does not contain type variables, it is a `monomorphic` type.
