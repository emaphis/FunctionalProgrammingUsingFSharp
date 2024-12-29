module Chapter04.Examples_04


// Example 4.1 -Removing elements from a list

/// Function `remove` whose values `remove(x, ys)` is the list obtained from `ys` by removing all occurrences of `x`.
let rec remove= function
    | _, []    -> []
    | x, y::ys ->
        if x=y then remove(x, ys)
        else y :: remove(x, ys) ;;

// val remove: x: 'a * ys: 'a list -> 'b list when 'a: equality

let lst1 : string list = remove("a", ["a"; "abc"; "A"; "a"]) ;;
//val lst1: string list = ["abc"; "A"]


/// Function whose value is the list obtained from`xs`, which occurs earlier in xs.
let rec removeDub = function
    | []    -> []
    | x::xs -> x :: removeDub(remove(x, xs)) ;;

// val removeDub: _arg1: 'a list -> 'a list when 'a: equality


// Example 4.2 - A register for CDs.

type CD = {
    Title : string
    Artist : string
    Company : string
    Year : int
    Songs : string list
} ;;

type CDRegister = CD list ;;

// Example of a register

let cdreg =
    [ { Title="tl"; Artist="al"; Company="cl";
        Year=93; Songs = [ "sl"; "s2"; "s3"; "s4";  "sS"] };
      { Title="t2"; Artist="a2"; Company="c2";
        Year=91; Songs=[ "s6"; "s7";  "s8"; "s9" ] };
      { Title="t3"; Artist="al"; Company="c2";
        Year=94; Songs= [ "s10"; "s11"; "s12" ] }
    ] ;;


/// Extract from a register the titles of the CDs for a given artist
let rec titles = function
    | _, ([] : CDRegister) -> []
    | a, { Artist=artist; Title=title; Company=_; Year=_; Songs=_ } :: cdreg ->
        if a = artist then title::titles(a, cdreg)
        else titles(a, cdreg)

// val titles: a: string * cdreg: CDRegister -> string list

let list1 = titles("al", cdreg)
//val list1: string list = ["tl"; "t3"]


/// Extracting an artist is a partial function
exception CdEx

/// Extracting the artist of a given song in a register
let rec findArtist = function
    | (_, []: CDRegister)  -> raise CdEx
    | s, { Artist=artist; Title=_; Company=_; Year=_; Songs=songs } :: cdreg ->
        if (List.contains s songs) then artist
        else findArtist(s, cdreg)

// val findArtist: string * CDRegister -> string

//let art1 = findArtist("s7", cdreg);;
//val art1: string = "a2"

//let art2 = findArtist("s88", cdreg);;
// FSI_0026+CdEx: CdEx
