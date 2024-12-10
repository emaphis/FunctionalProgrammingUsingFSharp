module Chapter03.Exercise_03_02

(*
Exercise 3.2

 The former British currency had 12 pence to a shilling and 20 shillings to a pound.
 Declare functions to add and subtract two amounts, represented by triples
 (pounds,shillings,pence) of integers, and declare the functions when a representation
 by records is used. Declare the functions in infix notation with proper precedences, and
 use patterns to obtain readable declarations.
*)

// Rates:  12 pence to a shilling
//         20 shilling to a pound
//         1 pound to a pound


/// Normalize a British currency triple.
let rec normalize (pounds, shillings, pence) =
    match (pounds, shillings, pence) with
    | (pounds, shillings, pence) when pence >= 12 ->
        normalize (pounds,shillings + pence / 12, pence%12)
    | (pounds, shillings, pence) when shillings >= 20 ->
        normalize (pounds + shillings/20,shillings%20, pence%12)
    
    
    | (pounds, shillings, pence) -> (pounds, shillings, pence)
    


normalize (0, 0, 11) = (0, 0, 11)
normalize (0, 0, 12) = (0, 1, 0)
normalize (0, 0, 13) = (0, 1, 1)
normalize (0, 0, 24) = (0, 2, 0)
normalize (0, 19, 0) = (0, 19, 0)
normalize (0, 20, 0) = (1, 0, 0)
normalize (0, 21, 0) = (1, 1, 0)
normalize (1, 19, 12) = (2, 0, 0)
normalize (0, 0, 24) = (0, 2, 0)
normalize (0, 38,24) = (2, 0, 0)

