# Examples from the end of Chapter 4

## 4.1 Removing elements from a list

A function `remove` whose values $remove(x, ys)$ is the list obtained from $ys$ by removing all occurrences of $x$.

It is declared by:

```fsharp
let rec remove= function
    | _, []    -> []
    | x, y::ys ->
        if x=y then remove(x, ys)
        else y :: remove(x, ys) ;;

// val remove: x: 'a * ys: 'a list -> 'b list when 'a: equality

let lst1 : string list = remove("a", ["a"; "abc"; "A"; "a"]) ;;
//val lst1: string list = ["abc"; "A"]
```

Consider the function `removeDum` whose value $removeDub(xs)$ is the list obtained from $xs$ by
removing all the elements of $xs$, which occur earlier in $xs$.

```fsharp
let rec removeDub = function
    | []    -> []
    | x::xs -> x :: removeDub(remove(x, xs)) ;;

// val removeDub: _arg1: 'a list -> 'a list when 'a: equality

emoveDub [1;2;2;1;4;1;5];;
//val it: int list = [1; 2; 4; 5]
```

## Example 4.2

### A register for CDs

This will be an example using a record and list patterns to produce succinct function declarations.

A register describing CDs, where each CD is described by `title`, `artist`, `record company`, `year` and the songs on the disk.

```fsharp
type CD = {
    Title : string
    Artist : string
    Company : string
    Year : int
    Songs : string list
} ;;

type CDRegister = CD list ;;
```

An example register

```fsharp
et CDReg =
    [ { Title="tl"; Artist="al"; Company="cl";
        Year=93; Songs = [ "sl"; "s2"; "s3"; "s4";  "sS"] };
      { Title="t2"; Artist="a2"; Company="c2";
        Year=91; Songs=[ "s6"; "s7";  "s8"; "s9" ] };
      { Title="t3"; Artist="al"; Company="c2";
        Year=94; Songs= [ "s10"; "s11"; "s12" ] }
    ] ;;
```

Function to extract from a register the titles of eDs for a given artist:

```fsharp
let rec titles = function
    | _, ([] : CDRegister) -> []
    | (a, { Artist=artist; Title=title; Company=_; Year=_; Songs=_ } :: cdreg) ->
        if a = artist then title::titles(a, cdreg)
        else titles(a, cdreg)

// val titles: a: string * cdreg: CDRegister -> string list

let list1 = titles("al", cdreg)
//val list1: string list = ["tl"; "t3"]
```

Extracting an artist of a given song is a partial function since the register may not contain a CD with that song.
So we declare an exception

```fsharp
exception CdEx

let rec findArtist = function
    | (_, []: CDRegister)  -> raise CdEx
    | (s, { Artist=artist; Title=title; Company=_; Year=_; Songs=songs } :: cdreg) ->
        if (List.contains s songs) then artist
        else findArtist(s, cdreg)

// val findArtist: string * CDRegister -> string
```

A test run

```fsharp
let art1 = findArtist("s7", cdreg);;
//val art1: string = "a2"

//let art2 = findArtist("s88", cdreg);;
// FSI_0026+CdEx: CdEx
```
