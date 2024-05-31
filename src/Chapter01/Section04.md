# 1.4 Recursion

This section introduces the concept of recursion formula and recursive declaration of functions by an example: the factorial function n!.

It is defined by:

$0! = 1 \\
{n! = 1 \cdot 2 \cdot ... \cdot n} \space \space \space  {for} \space {n > 0}$

where `n` is a non-negative integer. The dots ... will be multiplied. For example:

$4! = 1 \cdot 2 \cdot 3 \cdot 4 = 24$

## Recursion formula

The underbraced part of the below expression for $n!$ is the expression for $(n − 1)!$:

$n! = \underbrace{1 \cdot 2 \cdot ... \cdot (n - 1) \cdot n}_{n-1}! \cdot n \space \space  for \space n > 1$

We get the formula

$n! = n \cdot (n - 1)! \space \space \space for \space n > 1$

This formula is correct for $n = 1$ so:

$0! = 1$ and $1 \cdot (1 - 1)! = 1 \cdot 0! = 1 \cdot 1 = 1$

thus we get:

$0! = 1 \quad \quad \quad \quad \text{ (Clause 1)}\\
n! = n \cdot (n - 1)! \space for \space n > 0 \quad \text{ (Clause 2)}$

This formula is called a `recursion formula` for the factorial function $(\dots!)$ as it expresses the value of the function for some argument $n$ in terms of the value of the function for some other argument here $(n-1)$.

## Computations

This formula can be used fo computation:

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

$$
\begin{alignat}{2}
   10&x+&3&y=2\\
   3&x+&13&y=4
\end{alignat}
$$

$$
\begin{aligned}
3     &= 4 \cr
a + b &= c
\end{aligned}
$$

$$
\displaystyle
\left( \sum_{k=1}^n a_k b_k \right)^2
\leq
\left( \sum_{k=1}^n a_k^2 \right)
\left( \sum_{k=1}^n b_k^2 \right)
$$
