module Chapter04.MapColouring_04_06

// Examples. A model-based approach 4.6

// needed by the program

/// List membership
let rec isMember x = function
    | y :: ys  -> x = y || (isMember x ys)
    | []  -> false

// val isMember: x: 'a -> _arg1: 'a list -> bool when 'a: equality

// Data definitions

/// A country is represented by a name
type Country = string

/// A Boarder is a pair representing two bordered counttries
type Border = Country * Country

/// A list of borders representing neighbour relations
type Map = Border list

// Example - Colouring problem with 4 countries
//let exMap : Map = [("a", "b"); ("c", "d"); ("d", "a")]

/// A Colour on a map is repressented by a list of `countries` having this colour.
type Colour = Country list

/// A list of mutually disjoint `colours`
type Colouring = Colour list


// Programming

//A Data model for map colouring problem

//| Meta symbol: Type | Definition             | Sample value            | 
//|-------------------|------------------------|-------------------------|
//| c: Country        | string                 | "a","b","c","d"         |
//| b: Border         | (Country*Country)      | ("a"; "b")              |
//| m: Map            | (Country*Country) list | [(a","b");             |
//|                   |                        |   ("c","d"); ("d","a")] |
//| col: Colour       | Country list           | ["a"; "c"]              |
//| cols: Colouring   | Colour list            | [["a";"c"];["b";"d"]]   |


(*
/// Predicate that determines if two countries share a border.
let rec areNB m c1 c2 =
    match m with
    | []                                 -> false
    | b :: _ when fst b = c1 && snd b = c2 -> true
    | b :: _ when snd b = c1 && fst b = c2 -> true
    | _ :: m                          -> areNB m c1 c2 
*)

/// Predicate that determines if two countries share a border.
let rec areNB m c1 c2 =
    isMember (c1, c2) m || isMember (c2, c1) m

//val areNB:
//  map: ('a * 'a) list -> cnt1: 'a -> cnt2: 'a -> bool when 'a: equality


/// Predicate to determine for a given map whether a colour can be ex￾tended by a country
let rec canBeExtendBy m col c =
    match col with
    | []         -> true
    | c' :: col' -> not (areNB m c' c) && canBeExtendBy m col' c

// val canBeExtendBy:
//    m: ('a * 'a) list -> col: 'a list -> c: 'a -> bool when 'a: equality

/// for a given map extend a partial colouring by a country
let rec extColouring m cols c =
    match cols with
    | []           -> [[c]]
    | col :: cols' ->
        if canBeExtendBy m col c
        then (c :: col) :: cols'
        else col :: extColouring m cols' c

//val extColouring:
//  m: ('a * 'a) list -> cols: 'a list list -> c: 'a -> 'a list list
//    when 'a: equality

/// Only add element if it's not already present.
let addElem x ys =
    if isMember x ys then ys else x::ys

// Add a pair of countries (border?) to a list if they aren't already their
let rec countries = function
    | []        -> []
    | (c1, c2) :: m -> addElem c1 (addElem c2 (countries m))
// val countries: _arg1: ('a * 'a) list -> 'a list when 'a: equality

/// Colour a list of countries given a map
let rec colCountries m = function
    | []   -> []
    | c::cs -> extColouring m (colCountries m cs) c

//val colCountries:
//    m: ('a * 'a) list -> _arg1: 'a list -> 'a list list when 'a: equality

/// Produces a colouring for a given map
let colMap map =
    colCountries map (countries map)

// val colMap: map: ('a * 'a) list -> 'a list list when 'a: equality

(*
// Examples

// Example - Colouring problem with 4 countries
let exMap : Map = [("a", "b"); ("c", "d"); ("d", "a")]

// should produce the example colouring
let exColouring = [["a"; "c"]; ["b"; "d"]]


let bool1 = canBeExtendBy exMap ["c"] "a" = true

let bool2 = canBeExtendBy exMap ["a"; "c"] "b" = false


let cols1 = extColouring exMap [] "a" = [["a"]]
//val cols1: Country list list = [["a"]]

let cols2 = extColouring exMap [["c"]] "a" = [["a"; "c"]]
//val cols2: Country list list = [["a"; "c"]]

let cols3 = extColouring exMap [["b"]] "a"  = [["b"]; ["a"]]
//val cols3: Country list list = [["b"]; ["a"]]


let colouring = colMap exMap = exColouring
//val colouring: Country list list = [["c"; "a"]; ["b"; "d"]]
*)
