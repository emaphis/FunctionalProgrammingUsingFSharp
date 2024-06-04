// 2.5 Overloaded functions and operators

// + can be used to add floats, integers, and concatenaate strings

// If the type can be inferred from the context.

// if not the type can be specified 

// obvious interpretation.

let squareI x = x * x
// val square: x: int -> int

// specifying the parameter type
let squareF1 (x: float) = x * x
// val squareF1: x: float -> float

// specifying the return type
let squareF2 x = x * x : float
// val squareF2: x: float -> float

// or chosing a to build from a typed function:
// abs, acos, atan, atan2, ceil, cos, cosh, exp, floor, log
// log10, pow, pown, round, sin, sinh, sqrt, tan, tanh

// abs is overloaded

abs -1
// val it: int = 1

abs -1.0
// val it: float = 1.0

abs -1.0f
// val it: float32 = 1.0
