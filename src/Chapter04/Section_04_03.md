# 4.3 Typical recursions over lists

Arch-typical recursive functions declarations on lists.

## Function declarations with two clauses

The function $suml$ which computes the sum a list of integers:

$$
suml \space [x_0; x_1;...;x_{n-1}] \space = \space \sum^{n-1}_{i=0}x_i=x_0+x_1+...+x_{n-1} \space = \space x_0 + \space \sum^{n-1}_{i=1}x_i
$$

The recursion formula:

$$ suml [x_0; x_1; ...;x_{n-1}] \space = \space x_0 + suml [x_1; ...; x_{n-1}]$$

The function definition:

```fsharp
let rec suml = function
    | []    -> 0
    | x::xs -> x + suml xs;;
val suml: _arg1: int list -> int
```

In evaluating the function for $suml xs$, F# scans the clauses and selects the first clause where the argument matches the pattern.

$$
\begin{align*}
    &suml \space [1;2] \\
\rightsquigarrow & + suml [2] \qquad      &(x::xs \space matches \space [1;20] \space with \space x \mapsto 1 \space and \space xs \mapsto [2]) \\
\rightsquigarrow & + (2 \space + \space suml \space []) &(x::xs \space matches \space [2] \space x \mapsto 2 \space and \space xs \mapsto [\space]) \\
\rightsquigarrow & \space 1 \space + \space (2 \space + \space 0)  & (the \space pattern \space [\space] \text(matches \space the \space value) \space [\space]) \\
\rightsquigarrow & \space 1 \space + \space 2 \\
\rightsquigarrow & \space 3
\end{align*}
$$

## Function declarations with several clauses

A function declaration can have more than one clause

Consider the `altsum` function on an integer list:

$$altsum \space [x_0;x_1; ...; x_{x-1}] \space = \space x_0 - x_1 + x_2 - ...; + (-1)^{n-1} x_{n-1}$$

We have three different forms of arguments.

1. empty list: $\quad altsum \space [\space] \space = \space 0$

2. list with one element: $altsum \space [x_0] \space = \space x_0$

3. list with two oar move elements:

    $$altsum \space [x_0;x_1;x_2;\dots;x_{n-1}] \space = \space x_0 - x_1 + altsum \space [x_2; \dots;x_{n-1}]$$

The function can be declared as:

```fsharp
let rec altsum = function
    | []    -> 0
    | [x]   -> x
    | x0::x1::xs -> x0 - x1 + altsum xs;;
// val altsum: _arg1: int list -> int

>  altsum [2;-1; 3];;
val it: int = 6
```

## Layered patterns

A function $succPairs$ such that

$$
\begin{align*}
&succPairs \space \space [\space]     & \quad = \space [\space] \\
&succPairs \space [x]          & \quad = \space [\space] \\
&succPairs \space [x_0;x_1;...;x_{n-1}] & \quad = \space [(x_0,x_1);(x_1,x_2); ...; (x_{n-2},x_{n-1})]
\end{align*}
$$

Using the pattern $x0::x1::xs$ we get the declaration:

```fsharp

```fsharp 
let rec succPairs = function
    | x0::x1::xs -> (x0, x1) :: succPairs(x1::xs)
    | _ -> [];;
//val succPairs: _arg1: 'a list -> ('a * 'a) list
```

Or simpler:

```fsharp
let rec succPairs = function
    | x0::(x1::_ as xs) -> (x0, x1) :: succPairs xs
    | _  -> [];;
// val succPairs: _arg1: 'a list -> ('a * 'a) list

> succPairs [1;2;3];;
val it: (int * int) list = [(1, 2); (2, 3)]
```

The pattern $x1:: \space \_ \space as \space xs$ is an example of a `layered pattern`. A layered pattern has the general form:

$$pat \space as \space id$$

with pattern $pat$ and identifier $id$. The matching binds identifiers in the pattern $pat$ as usual with the addition that the identifier $id$ is bound to $val$. The matching list $[x_0;x_1;\dots]$ with the pattern $x0::\_ as \space xs$ will give the bindings:

$$
\begin{align*}
& x0 \mapsto x_0 \\
& x1 \mapsto x_1 \\
& xs \mapsto [x_1; ...]
\end{align*}
$$

## Pattern matching on result of recursive call

Use pattern matching to split the result of a recursive call into components.  The function $sumProd$ computes the pair consisting of the sum and the production of the elements in a list of integers.

$$
\begin{align*}
sumProd \space [x_0;x_1;...;x_{n-1}] \\
\space  &= \space [x_0 + x_1 + ... + x_{n-1}, \space x_0 * x_1 * ... * x_{n-1}]  \\
\space sumProd \space [\space] &= (0,1)
\end{align*}
$$

The declaration is based on the recursion formula:

$$
sumProd \space [x_0;x_1;\dots;x_{n-1}] \space = \space (x_0 + rSum, \space x_0 * rProd)
$$

where

$$
(rSum, \space rProd) \space = sumProd \space [x_1; \dots; x_{n-1}]
$$

This gives the declaration:

```fsharp
let rec sumProd = function
    | []    -> (0, 1)
    | x::rest ->
        let (rSum, rProd) = sumProd rest
        (x+rSum, x*rProd);;
//val sumProd: _arg1: int list -> int * int

> sumProd [2;5];;
val it: int * int = (7, 10)
```

Another example is the $unzip$ function tha maps a list of pairs to a pair of lists:

$$
unzip \space ([(x_0, Y_0); (x_1,y_1); \dots; (x_{n-e}, y_{n-1}) \space] \newline
\qquad = \space ([x_0;x_1;\dots;x_{n-1}], \space [y_0;y_1;\dots;y_{n-1}]))
$$

The declaration of $unzip$:

```fsharp
let rec unzip = function
    | []          -> ([], [])
    | (x,y)::rest ->
        let (xs, ys) = unzip rest
        (x::xs, y::ys);;
//val unzip: _arg1: ('a * 'b) list -> 'a list * 'b list

> unzip [(1,"a");(2,"b")];;
val it: int list * string list = ([1; 2], ["a"; "b"])
```

The $unzip$ function is found as $List.unzip$ in the F# library.

## Pattern matching on pairs of lists

A function $mix$ that mixes the elements of two lists of the same length:

$$
mix \space ([x_0;x_1; \dots; x_{n-1}], \space [y_0;y_1; \dots; y_{n-1}]) \\
\qquad = \space [x_0; y_0; x_1; y_1; \dots; x_{n-1}; y_{n-1}]
$$

```fsharp
let rec mix = function
    | (x::xs, y::ys) -> x::y::(mix (xs, ys))
    | ([], [])       -> []
    | _              -> failwith "mix: parameter error";;
//val mix: 'a list * 'a list -> 'a list

> mix ([1;2;3],[4;5;6]);;
val it: int list = [1; 4; 2; 5; 3; 6]
```

The corresponding higher-order function is defined using a match expression:

```fsharp
let rec mix xlst ylst =
    match (xlst, ylst) with
    | (x::xs, y::ys) -> x::y::(mix xs ys)
    | ([],[])        -> []
    | _              -> failwith "mix: parameter error";;
//val mix: xlst: 'a list -> ylst: 'a list -> 'a list

> mix [1;2;3] [4;5;6];;
val it: int list = [1; 4; 2; 5; 3; 6]
```
