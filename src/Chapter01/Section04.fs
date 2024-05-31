namespace Chapter01

module Section04 =

 (*
    a recursion formula:

    0! = 1                      (Clause 1)
    n! = n · (n − 1)! for n > 0 (Clause 2)   
 *)

    // Recursive declaration

    let rec fact = function
        | 0 -> 1                                // Clause 1
        | n -> n * fact (n - 1)      // Clause 2

    let bool1 = 24 = fact 4
