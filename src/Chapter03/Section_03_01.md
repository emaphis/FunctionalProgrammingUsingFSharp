# 3.1 Tuples

An ordered collection of $n$ values $(v_1,v_2, ... , v_n)$, where $n > 1$, is called an $n-tuple$.

Examples of $n-tuples$ are:

```fsharp
(10, true)
// > val it: int * bool = (10, true)

(("abc", 1), -3)
// > val it: (string * int) * int = (("abc", 1), -3)
```

A $2-tuple$ is a called a pair. The second example is a pair contains another pair.

A 3-tuple is called a triple and a 4-tuple is called a quadruple. There ae no 1-tuples or 0-tuples. An expression like $(true)$ is not a tuple but just the expression $true$ enclosed by parentheses.

The symbol $()$ is the only value of `unit`.

Tuples can also be considered graphs with $( v_1, v_2, ... , v_n )$ being an `n` graph.

The tuples $(true, "abd", 1, -3)$ and $((true,"abc"),1,-3)$ contain the same values but have a different structure. 

## Tuple expressions

A tuple expression $(expr_1, expr_2, ..., expr_n)$ is formed by enclosing $n$ expressions $expr_1, expr_2, ..., expr_n$ in parentheses.  It has the type $\tau_1 * \tau_2 * ... \tau_n$ when $expr_1, expr_2, ..., expr_n$ have the types $\tau_1 * \tau_2 * ... \tau_n$.

For example:

```fsharp
> (1<2,"abc",1,1-4);;
// > val it: bool * string * int * int = (true, "abc", 1, -3)

(true, "abc");;
// > val it: bool * string = (true, "abc")

> ((2>1,"abc"), 3-2, -3);;
// > val it: (bool * string) * int * int = ((true, "abc"), 1, -3)
```


```fsharp
let tp1 = ((1<2, "abc"), 1, 1-4)
> val tp1 : (bool * string) * int * int = ((true, "abc"), 1,-3)

let tp2 = (2>1, "abc", 3-2,-3)
> val tp2 : bool * string * int * int = (true, "abc", 1,-3)
```

## Tuple are individual values

Tuples may contain tuples bound to values:

```fsharp
 > let t1 = (true,"abc");;
 val t1 : bool * string = (true, "abc")
 
 > let t2 = (t1,1,-3);;
 val t2 : (bool * string) * int * int = ((true, "abc"), 1,-3)
```
A fresh binding of t1 is, however, not going to affect the value of t2:

```fsharp
 > let t1 =-7 > 2;;
 val t1 : bool = false
 
> t2;;
 val it : (bool * string) * int * int = ((true, "abc"), 1,-3)
```

The definition of $t2$ must be reevaluated. 

## Equality

Equality is defined for n-tuples of the same type, if equality is defined for all the subcomponents. Equality is calculated in order. $(v_1,v_2, ..., v_n)$ is equal to $(v_1', v_2', ... , v_n')$ if $v_1$ is equal to $v_1'$, of $1 \leq i \leq n$.

```fsharp
("abc", 2, 4, 9) = ("ABD", 2, 3, 9);;
// val it: bool = false

(1, (2,true)) = (2-1, (2,2>1));;
// val it: bool = true

(1, (2,true)) = (1, 2, 2>1);;
// stdin(6,18): error FS0001: Type mismatch. Expecting a tuple of length 2 of type
//     int * (int * bool)
// but given a tuple of length 3 of type
//     int * int * bool
```

The last example, the types don't match.

## Ordering

Using the `ordering` operators $>, \geq, <, and \leq$ and the `compare` function are defined on tuples of the same type, assuming that ordering is defined on the components. Tuples are ordered lexicographically.

$$
(x_1, x_2, ..., x_n) < (y_1,y_2,...,y_n)
$$

exactly when, for some $k$ where $1 \leq k \leq n$, we have:

$$
x_1=y_1 \space or \space x_2=y_2 \space or \space... \space or \space x_{k-1}=y_{k-1} || x_k<y_k
$$

```fsharp
(1, "a") < (1, "ab");;
// val it: bool = true

(2, "a") < (1, "ab");;
// val it: bool = false
```

since `"a" < "ab"` is true while `2 < 1` is false.

```fsharp
(’a’, ("b",true), 10.0) >= (’a’, ("b",false), 0.0);;
// val it: bool = true

compare ("abcd", (true, 1)) ("abcd", (false, 2));;
//val it: int = 1
```

## Tuple patterns

Patterns can be used on the left hand side of a `let` declaration to destructure tuples.

```fsharp
let (x,n) = (3,2);;
// val x: int = 3
// val n: int = 2
```

Patterns may contain constants

```fsharp
let (x, 0) = ((3, "a"), 0);;
//val x: int * string = (3, "a")
```

But this fails:

```fsharp
let (x,0) = (3,2);;
```

Since `0` doesn't match `2`

Wildcard patterns can be used in matching expressions

```fsharp
let ((_,x),_,z) = ((1,true), (1,2,3), false);;
// val z: bool = false
// val x: bool = true
```

Patterns can't contain multiple units of the same identifier

```fsharp
let (x,x) = (1,1);;
stdin(18,8): error FS0038: 'x' is bound twice in this pattern
```
