// 3.9 Enumeration types

module Section03_09

// Value constructors don't need arguments.

type Colour = Red | Blue | Green | Yellow | Purple

// These types are called `enumeration types` as a declaration like 'Coulour'
// just enumerates five constuctors

// Each constructor is a value of type 'Colour'

let clr1 = Green
// val clr1: Colour = Green

// Functions on enumerations types may be declared using pattern matching.

let niceColour = function
    | Red -> true
    | Blue -> true
    | _  -> false

// val niceColour: _arg1: Colour -> bool

let nice1 = niceColour Purple
// val nice1: bool = false

// The days in a mont example from Chapter 1 cam be expressed using an enumeation

type Month =
    | January | February | March | April
    | May | June | July | August | September
    | October | November | December


let daysOfMonth = function
    | February                             -> 28
    | April | June | September | November  -> 30
    | _                                    -> 31

// val daysOfMonth: _arg1: Month -> int
