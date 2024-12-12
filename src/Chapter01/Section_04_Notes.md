# 1.4 Recursion

Recursive functions are define with at least two cases:
  A base case which ends the recursive
  And a recursive case which makes the recursive call on on simpler arguments

This section introduces the concept of recursion formula and recursive declaration of functions by an example: the factorial function n!.

It is defined by:

$$
\begin{align}
0&! = 1 \\
n&! = 1 \cdot 2 \cdot ... \cdot n \space \space \space  for \space n > 0
\end{align}
$$

where $n$ is a non-negative integer. The dots $\cdots$ will be multiplied. For example:

$$4! = 1 \cdot 2 \cdot 3 \cdot 4 = 24$$

## Recursion formula

The underbraced part of the below expression for $n!$ is the expression for $(n − 1)!$

$$
n! = \underbrace{1 \cdot 2 \cdot ... \cdot (n - 1) \cdot n}_{n-1}! \cdot n \space \space  for \space n > 1
$$

We get the formula

$$
n! = n \cdot (n - 1)! \space \space \space for \space n > 1
$$

This formula is correct for $n = 1$ so:

$$
0! = 1 \quad and \quad 1 \cdot (1 - 1)! = 1 \cdot 0! = 1 \cdot 1 = 1
$$

thus we get:

$$
\begin{align}
0&! = 1 \quad \quad \quad \quad \text{ (Clause 1)}\\
n&! = n \cdot (n - 1)! \space for \space n > 0 \quad \text{ (Clause 2)}
\end{align}
$$

This formula is called a `recursion formula` for the factorial function $(\dots!)$ as it expresses the value of the function for some argument $n$ in terms of the value of the function for some other argument here $(n-1)$.

## Computations

This formula can be used for computation:

    4!
    = 4 * (4 - 1)!
    = 4 * 3!
    = 4 * (3 * (3 * 1)!)
    = 4 * (3 * 2!)
    = 4 * (3 * (2 * (2 - 1)!))
    = 4 * (3 * (2 * 1!))
    = 4 * (3 * (2 * (1 * (1 - 1)!)))
    = 4 * (3 * (2 * (1 * 0!)))
    = 4 * (3 * (2 * (1 * 1)))
    = 24
