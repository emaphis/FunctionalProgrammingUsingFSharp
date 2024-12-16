module Chapter03.Exercise_03_02

(*
Exercise 3.2

 The former British currency had 12 pence to a shilling and 20 shillings to a pound.
 Declare functions to add and subtract two amounts, represented by triples
 (pounds,shillings,pence) of integers, and declare the functions when a representation
 by records is used. Declare the functions in infix notation with proper precedences, and
 use patterns to obtain readable declarations.
*)

// Note: Really all amounts should be converted to pence than manipulated the normalized back into
// pounds, shillings and pence but that is not keeping with the spirit of the exercises.

// Rates:  12 pence to a shilling
//         20 shilling to a pound
//         1 pound to a pound


type Currency = int * int * int

/// Normalize a British currency triple.
let rec normalize (curr: Currency) =
    let pounds, shillings, pence = curr
    match (pounds, shillings, pence) with
    | (pnds, slng, pnce) when pnce >= 12 ->
        normalize (pnds,slng + pnce / 12, pnce % 12)
    | (pnds, slng, pnce) when pnce < 0 ->
        normalize (pnds,slng - 1, pnce + 12)
    | (pnds, slng, pnce) when slng >= 20 ->
        normalize (pnds + slng / 20,slng % 20, pnce % 12)
    | (pnds, slng, pnce) when slng < 0 ->
        normalize (pnds - 1,slng + 20, pnce)
    | (pnds, slng, pnce) -> (pnds, slng, pnce)



let addP (pounds1, shillings1, pence1) (pounds2, shillings2, pence2) : Currency =
    normalize (pounds1 + pounds2, shillings1 + shillings2, pence1 + pence2)

let subtP (pounds1, shillings1, pence1) (pounds2, shillings2, pence2) : Currency =
    normalize (pounds1 - pounds2, shillings1 - shillings2, pence1 - pence2)


let (+.) curr1 curr2 = addP curr1 curr2

let (-.) curr1 curr2 = subtP curr1 curr2


/// A Record representation of Brithish currncy
type CurrencyR =
    {
        Pounds : int
        Shillings : int
        Pence : int
    }


/// Normalize a British Currency record
let rec normalizeR (curr: CurrencyR) =
   // let pounds, shillings, pence = curr
    match curr with
    | curr when curr.Pence >= 12 ->
        normalizeR { curr with Shillings = curr.Shillings + (curr.Pence / 12); Pence = curr.Pence % 12}
    | curr when curr.Pence < 0 ->
        normalizeR { curr with Shillings = curr.Shillings - 1; Pence = curr.Pence + 12 }
    | curr when curr.Shillings >= 20 ->
        normalizeR { Pounds =  curr.Pounds + (curr.Shillings / 20);  Shillings = curr.Shillings % 20; Pence =  curr.Pence % 12 }
    | curr when curr.Shillings < 0 ->
        normalizeR { Pounds = curr.Pounds - 1; Shillings = curr.Shillings + 20; Pence =  curr.Pence }
    | curr -> curr


let addR (curr1: CurrencyR) (curr2: CurrencyR) : CurrencyR =
    normalizeR { Pounds = curr1.Pounds + curr2.Pounds; Shillings =  curr1.Shillings + curr2.Shillings; Pence = curr1.Pence + curr2.Pence }

let subtR curr1 curr2 : CurrencyR =
    normalizeR { Pounds = curr1.Pounds - curr2.Pounds; Shillings = curr1.Shillings - curr2.Shillings; Pence =  curr1.Pence - curr2.Pence }


let (++) curr1 curr2 = addR curr1 curr2

let (--) curr1 curr2 = subtR curr1 curr2
