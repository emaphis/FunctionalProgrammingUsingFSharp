// Section 1.1 - Values, types, identifiers and declarations

// Using F# in interactive mode
// You can enter thise expressions in interactive mode for testing
2*3 + 4
// val it: int = 10
// value called it with the vaule of 1o and type of int

let price = 125  // new declaration of an identifier
// val price: int = 125

// We say 123 is bound to identifier `price`
// Identifiers can be reused in further expressions

//> price * 20;;
//val it : int = 2500


let tot = price * 20
// val it: int = 2500

//> it / price = 20;;
// val it : bool = true

tot / price
// val it: int = 20