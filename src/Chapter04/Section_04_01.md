# 4.1 The concept of a list

A list defines a sequence of values of the same type:

$$[v_0; v_1; ...; v_{n-1}]$$

For example $[3], [3; 2], and \space [2; 3; 1]$ are lists of integers. A list contains an arbitrary number of items.

## List constants in F#

```FSharp
> let xs = [2;3;2];;
val xs: int list = [2; 3; 2]

> let ys = ["Big"; "Mac"];;
val ys: string list = ["Big"; "Mac"]
```

The types $int \space list$ and $string \space list$ contain the `type constructor` $list$.

List of pairs

```fsharp
>  [("b",2);("c",3);("e",5)];;
val it: (string * int) list = [("b", 2); ("c", 3); ("e", 5)]
```

List of records:

```fsharp
>  type P = {name: string; age: int}
 [{name = "Brown"; age = 25}; {name = "Cook"; age = 45}];;

 val it: P list = [{ name = "Brown"
                    age = 25 }; { name = "Cook"
                                  age = 45 }]
```

lists of functions:

```fsharp
> [sin; cos];;
val it: (float -> float) list = [<fun:it@7>; <fun:it@7-1>]
```

List of lists:

```fsharp
> [[2;3];[3];[2;3;3]];;
val it: int list list = [[2; 3]; [3]; [2; 3; 3]]
```
Lists can be components of other types, pairs containing lists:

```fsharp
> ("bce", [2;3;5]);;
val it: string * int list = ("bce", [2; 3; 5])
```

## The type constructor $list$

The type constructor $list$ has higher precedence that `*` and `->` in `type expressions`, of the type $string \space *  \space int \space * list$ means $string \space * \space (int \space list)$.  The $list$ constructor is used as a postfix operator that associates left so $int \space list \space list$ means $(int \space list) \space list$.

All elements of a list must have the same type:

```fsharp
> ["a";1];;

  ["a";1];;
  -----^

stdin(2,6): error FS0001: All elements of a list must be implicitly convertible to the type of the first element, which here is 'string'. This element has type 'int'.
```

## Graph for a list

A non-empty list $[x_1;x_2;\dots;x_n]$ with $n\geq 0$ consists of two parts: the first element $x_1$ called the `heat` of the list and the remaining
part $[x_2; \dots; x_n]$ is called the tail of the list. The head of $[2;3;4]$ is $2$ and the tail is $[3;4]$.
The head of $[2]$ is $2$ while the tail is $[\space]$.

The list in F# is essentially a graph. 

## Equality of lists.

Two lists $[x_0; x_1; ...; x_{m-1}]$ and $[y_0;y_1;...; y_{n-1}]$ (of the same type) are `equal` when $m \space = \space n$ and $x_i = y_i$ and that $0 \leq i \lt m$. The order has to be the same

The equality operator `=` of F# can be used to test equality of two lists if the elements of the list are the same type:

```fsharp
> [2;3;2] = [2;3];;
val it: bool = false

> [2;3;2] = [2;3;3];;
val it: bool = false
```

List containing functions can't be compared since functions have no defined quality.

## Ordering of lists

Lists of the same type are ordered lexicographically, if there is an ordering defined on the elements.

There are two cases in this definition of $xs < ys$

1. The list $xs$ is a proper prefix of $ys$:

```fsharp
>  [1; 2; 3] < [1; 2; 3; 4];;
val it: bool = true


> ['1'; '2'; '3'] < ['1'; '2'; '3'; '4'];; 
val it: bool = true
```

 The empty list is smaller than any non-empty list:

 ```fsharp
> [] < [1; 2; 3];;
val it: bool = true

> [] < [[]; [(true,2)]];;
val it: bool = true
```

 2. The lists agree on the first $k$ elements and $x_{k+1} < y_{k+1}$.

```fsharp
> [1; 2; 3; 0; 9; 10] < [1; 2; 3; 4];;
val it: bool = true

> ["research"; "articles"] < ["research"; "books"];;
val it: bool = true
```

The other comparison relations can be defined in terms of `=` and `<`

```fsharp
> [1; 1; 6; 10] >= [1; 2];;
val it: bool = false
```

The $compare$ function is defined for lists, provided it is defined for the element type.

```fsharp
>  compare [1; 1; 6; 10] [1; 2];;
val it: int = -1

> compare [1;2] [1; 1; 6; 10];;
val it: int = 1
```
