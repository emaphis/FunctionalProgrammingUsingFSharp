#  3.7 Example: Rational numbers. Invariants

## Problem solving 1

This is one approach to program development. We will identify a number of problem development activities in terms of documents of each activity.
These documents constitute the essence of the `techical documentations` of a program.

We will develop a small (Rational number) example. It will provide an example that:

- is compact, in a standardized and readable form of technical document and
- assistance in decomposing and mastering difficult problems.

Three activities:

1. `Problem analysis` During this activity the necessary data and functions (including exceptions and constants) will be identified and their type specified. Thus, the result of this activity is an agenda for the programming activity.
2. `Programming` The entities specified in the problem analysis are elaborated into a program.
3. `Testing` The functions of the program are tested using selected test cases.

These three steps wil be iterated. Problems in the Programming and Testing stages will find weaknesses in the Analysis stage.

These activities will result in the `technical documentation` consisting of the following:

1. `Interface definition` The users view of the program is presented in the interface. The interface contains the declaration of the types of data and a specification of each function.
2. `Program` A declaration of each entity in the interface definition.
3. `Test` Set of tests with predicted result for program runs or unit tests. 

## Problem statement: rational numbers.

A number $q$ is `rational` if $q \space = \frac a b$, where $a$ and $b$ are integers and $b \space \neq 0$, The problem is to construct a program to perform the usual arithmetic operations on the rational numbers:
addition, subtraction, multiplication, division and equality. It should also provide a method to produce textual output. 

## Solution 1

### Problem analysis

Operators based on following the well-known laws of arithmetic:

$
\qquad \frac a b + \frac c d \space = \space \frac {ad \space + bc} {bd}
$

$
\qquad \frac a b - \frac c d \space = \space \frac a b \space + \frac {-c} d \space = \space \frac {ad \space - bc} {bd}
$

$
\qquad \frac {a} {b} \space . \space \frac c d \space = \space \frac {ac} {bd}
$

$
\qquad \frac {a} {b} \space / \space \frac c d \space = \space \frac a b \space . \space \frac d c \space where \space c \neq 0
$

$
\qquad \frac {a} {b} = \frac c d \quad \text{iff} \quad ad \space = \space bd
$

Give the data type `ratiaonal number` a name $qnum$

Use identifiers +., -., /., and =. as the names of the operators.

Division (//) is a partial function so it will need an exception $QDiv$ to represent numbers outside of its domain.

$mkQ$ constructs the rational number from a pair of floats $(a,b)$

$toString$ will convert a rational number to its textual representation.


| Specification             | Comment                            |
|---------------------------|------------------------------------|
| type qnum = int * int     | Rational numbers                   |
| exception QDiv            | Division by zero                   |
| mkQL : int * int -> qnum  | Construction of rational numbers   |
| .+. : qnum * qnum -> qnum | Addition of rational numbers       |
| .-. : qnum * qnum -> qnum | Subtraction of rational numbers    |
| .*. : qnum * qnum -> qnum | Multiplication of rational numbers |
| ./. : qnum * qnum -> qnum | Division of rational numbers       |
| .=. : qnum * qnum -> qnum | Equality of rational numbers       |
| toString : qnum -> string | String representation of rationals |

This is a list of specifications. Each is programming task that must be performed.

### Programming

In this solution we will consider the pair $(a,b)$ to represent the rational number $a/b$. The pair $(a,b)$ has the type $int * int$.

```fsharp
type Qnum = int * int  // (a,b) where b <> 0
```

The function $mkQ$ forms a rational humber from a pair of integers. It is a partial function where it is undefined for $b \neq 0$

```fsharp
exception QDiv;;

let mkQ pair : Qnum =
 match pair with
 | _, 0 -> raise QDiv
 | a, b -> a, b ;;
 
//val mkQ: 'a * int -> 'a * int

let rec gcd (m, n) =
    if m = 0 then n
    else gcd (n % m, m);;
```
Now the operators:

```fsharp
// Addition
let (.+.) (a, b) (c, d) = (a*d + b*c, b*d)

// Subtraction
let (.-.) (a, b) (c, d) = (a*d - b*c, b*d)

// Multiplication
let (.*.) (a, b) (c, d) = (a*c, b*d)

// Division
let (./.) (a, b) (c, d) = (a,b) .*. mkQ(d,c)

// Equality
let (.=.) (a, b) (c, d) = (a, b) = (c, d)

let toString(p, q) =
    let sign = if p*q < 0 then "-" else ""
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    sign + (ap % d).ToString() +
         "/" + (aq % d).ToString()
```

See the program in Section_03_07_A.fs

### Testing

A test should exercise all parts (or paths) of a program. Each case in a match expression should have a test.
Each brand in an &if ... then ... else ...$ should have a test case.

Test cases:

 | Case | Function | Branch   | Remark          |
 |------|----------|----------|-----------------|
 | 1    | mkQ      | (_, 0)   | Denominator = 0 |
 | 2    | mkQ      | pr       |                 |
 | 3    | .+.      |          |                 |
 | 4    | .-.      |          |                 |
 | 5    | .*.      |          |                 |
 | 6    | ./.      |          |                 |
 | 7    | .=.      |          |                 |
 | 10   | gcd      | (0, n)   | Base case       |
 | 11   | gcd      | (m, n)   | Recursive call  |
 | 8    | toString | p*q >= 0 | Negative sign   |
 | 9    | toString | p*q < 0  |                 |

See test\Chapter03\Section_03_07_a.ts

## Solution 2

In his version we use a representation of $(a, b)$ where $b \gt 0$ and where the fraction $\frac a b$ is irreducible, that is where $gcd(a,b) = 1$.
Any ration number has a unique `normal form` of this kind.

```fsharp
type QNum = int * int  // (a, b) where b > 0 and gce(a, b) = 1
```


It is convenient to declare a function `canc` which cancel common divisors and reduces any fraction with non-zero denominator to the normal form. 

```fsharp
/// Cancels common divisors and reduces the fraction p/q to it's normal form
let canc(p, q) =
    let sign = if p*q < 0 then -1 else 1
    let ap = abs p
    let aq = abs q
    let d = gcd(ap, aq)
    sign * (ap / d), aq / d

//val canc: p: int * q: int -> int * int
```
In other functions `canc` can be applied to ensure that the resulting value satisfy the invariant.

The resulting declaration of `toString` is simpler because the `QNums` are assumed to satisfy the invariant.

- No cancellation is needed.
- The integer $p$ and the rational number $\frac p q$ has the same sign (as $p \gt 0$)

### Programming

See the program in Section_03_07_B.fs

### Testing

Test cases:

| Case | Function | Branch   | Remark              |
|------|----------|----------|---------------------|
| 1    | canc     | p*q >= 0 | Non-negative number |
| 2    | canc     | p*q < 0  | Nagative number     |
| 3    | gcd      | (0, n)   | Base case           |
| 4    | gcd      | (m, n)   | Recursive call      |
| 5    | mkQ      | (_, 0)   | Denominator = 0     |
| 6    | mkQ      | pr       | Normal number       |
| 7    | .+.      |          |                     |
| 8    | .-.      |          |                     |
| 9    | .*.      |          |                     |
| 10   | ./.      |          |                     |
| 11   | .=.      |          |                     |
| 12   | toString |          |                     |

See test\Chapter03\Section_03_07_a.ts
