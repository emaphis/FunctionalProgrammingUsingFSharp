# Polymorphism

Next we cover polymorphism that deals with lists.  We will define three useful list functions based on the same structure of recursion we covered in Section 4.3.

## List membership

The list member function determines if a value $x$ is equal to one in the elements of a list $[y_0;y_1;\dots;y_{n-1}]$

$$
\begin{align*}
    &isMember \space x \space [y_0; y_1; \dots; y_{n-1}] \\
  = \space &(x\space = \space y_0) \space or \space (x\space = \space y_1) \space or \dots or \space (x \space = \space y_{n-}) \\
  = \space &(x\space = \space y_0) \space or \space (isMember \space x \space [y_1;\dots;y_{n-1}])
\end{align*}
$$

```fsharp
let rec isMember x = function
    | y::ys -> x = y || (isMember x ys)
    | []    -> false;;
//val isMember: x: 'a -> _arg1: 'a list -> bool when 'a: equality

> isMember 3 [1;2;3;4];;
val it: bool = true

> isMember 3 [1;2;2;4];;
val it: bool = false
```

## Append and reverse. Two built-in functions


The infix operator $@$ called `append` joins two lists of the same type:

$$
[x_0;x_1;\dots;x_{n-1}]\space @ \space[y_0;y_1;\dots;y_{n-1}]\space = \space
\space[x_0;x_1;\dots;x_{n-1};y_0;y_1;\dots;y_{n-1}]
$$

and the function $List.rev$ called `reverse` reverses a list:

$$
List.rev\space [x_0;x_1;\dots;x_{n-1}]\space = \space [x_n-1;\dots;x_1;x_0]
$$

These are defined in the F# libraries but their definitions reveal important issues in function design. The operator $@$ corresponds to the library function $List.append$:

$$
\begin{align*}
   [\space]& \space @ \space ys \space = \space ys \\
   [x_0;x_1;\dots;x_{m-1}]& \space @\space ys = \space x_0::([x_1;\dots;x_{m-1}]\space @ \space ys)
\end{align*}
$$

The definition

```fsharp
let rec (@) xs ys =
  match xs with
  | []    -> ys
  | x::xs' -> x::(xs' @ ys);;
//al (@) : xs: 'a list -> ys: 'a list -> 'a list

> [1;2] @ [3;4];;
val it: int list = [1; 2; 3; 4]
```

The evaluation

$$
\begin{align*}
          &[1;2]\space @ \space [3;4] \\
  \rightsquigarrow \space &1::([2] \space @ \space [3;4]) \\
  \rightsquigarrow \space &1::(2 \space :: \space [3;4]) \\
  \rightsquigarrow \space &1::[2;3;4] \\
  \rightsquigarrow \space &[1;2;3;4]
\end{align*}
$$

The evaluation of $xs \space @ \space ys$ comprises of $n+1$ pattern matches plus $m$ cons'es where $m$ is the length of $xs$.

Polymorphism is very convenient because one does not need to write special functions for every type:

```fsharp
> [1;2] @ [3;4];;
val it: int list = [1; 2; 3; 4]

> [[1];[2;3]] @ [[4]];;
val it: int list list = [[1]; [2; 3]; [4]]
```

The operators $::$ and $@$ have the same precedence and both associate to the $right$. So $[1] @2 :: [3]$ for example is interpreted as $[1]@(2::[3])$, while $1::[2]@[3]$ is interpreted as $1::([2] @ [3])$

```fsharp
> [1] @ 2 :: [3];;
val it: int list = [1; 2; 3]

> 1::[2] @[3];;
val it: int list = [1; 2; 3]
```

The `reverse` function $rev$, where:

$$
rev \space [x_0;x_1;\dots;x_{n-1}] \space = \space [x_{n-1};\dots;x_1;x_0]
$$

we have the recursion formula:

$$
rev \space [x_0;x_1;\dots;x_{n-1}] \space = \space (rev\space[x_1;\dots;x_1]) \space @ \space [x_0]
$$

because

$$
rev \space [x_1;\dots;x_{n-1}] \space = \space [x_{n-1};\dots;x_1]
$$

Giving us the declaration of a reverse function:

```fsharp
let rec naiveRev xls =
  match xls with
  | []    -> []
  | x::xs -> naiveRev xs @ [x];;
//val naiveRev: xls: 'a list -> 'a list

> naiveRev [1;2;3];;
val it: int list = [3; 2; 1]
```
