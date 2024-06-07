module Chapter02.Exercise_02_08


(*
    Exercise 2.8
    The following figure gives the first part of Pascal’s triangle:
        
        1
        1 1
        1 2 1
        1 3 3 1
        1 4 6 4 1

    The entries of the triangle are called binomial coefficients. The k'th binomial coefficient of the
    n'th row is denoted (n,k) for n>=0 and 0<=k<=n, For example: (2,1) = 2 and (4,2) = 6.  
    The first and last binomial coefficients, that is, (n,0) and (n,n) are both 1.
    A binomial coefficient inside a row is the some of the wo binomial coefficients immediatley above it.
    This properties can be expressed as follows

        (n,0) = (n,n) = 1
        (n,k) = (n-1,k-1) + (n-1,k)  if n<>0, k<>0 and n>k.

    Declare an F# function `bin: int * int 0> int` to compute the binomial coefficient.  
*)

/// Compute binomial coefficients
let rec bin(n, k) =
    match n, k with
    | n, 0  -> 1
    | n, k when n = k -> 1
    | n, k -> bin(n-1, k-1) + bin(n-1, k)

// val bin: n: int * k: int -> int
