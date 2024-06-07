module Chapter02.Exercise_02_11

(*
    Exercise 2.11
    
    Declare a function 'VAT: int -> float -> float' such that the value VAT n x is obtained
    by increasing x by n percent

    Declare a function 'unVAT: int -> float -> float' such that
    
        unVAT n (VAT n x) = x


    Hint: Use the conversion function float to convert an int value to a float value
*)


/// Calculate Value Added Tax
/// n = rate in whole number, x = amount
let VAT n x =
    let prct = (float n) / 100.0
    x + (x * prct)


/// n = rate in whole number, x = amount
let unVAT n x =
    let prct = (100.0 + (float n)) / 100.0
    x / prct

// val VAT: n: int -> x: float -> float
// val unVAT: n: int -> x: float -> float

