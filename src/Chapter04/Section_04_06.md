# 4.6 Examples. A model-based approach

Problem solving II

## A. Cash Register.

### Problem statement

The examples program models a cash register.

An electronic `cash register` contains a `data register` associating the `name of the article` and its `price` to each valid `article code`.
A `purchase` comprises a `sequence of items`. where each item describes the `purchase` of one of several `pieces of a specific article`.

The `task` is to construct a program which makes a `bill` of a purchase. 
For each `item` the bill must contain the `name of the article`, the `number of pieces`. and the `total price`, and the bill must also contain the `grand total` of the entire purchase.

We concentrate on describing the computations required in the example, and we do not describe the dialog between the operator and the system.
The construction of the dialog programs is addressed later.

### Problem analysis: cash register.

Our main goal is that the main concepts of the problem are found in the components of the program we will construct.
To achieve this we name the important concepts of the problem, and we associate types with those names.

Article code and article name are central concepts in the formulation. 

```fsharp
type articleCode = string;;
type articleName = string;;
```

We chose to represent these with strings

The `register` associates the `article name` and `article price` with each `article code`, ane we model a `register by a list of pairs.
Each pair has the form

$\qquad (ac, (aname, aprice))$

where $ad$ is an article code, $aname$ is the article name and $aprice$ is the article price.  We chose (non-negative) integers to represent prices in the smallest currency unit.

```fsharp
type price = int;;  // pr where pr >= 0
```

We get the following type for a `register`.

```fsharp
type register = (articleCode * (articleName * price)) list
```

The following is an example of a register:

```fsharp
let register : register =
    [ ("a1", ("cheese", 25));
      ("a2", ("herring", 4));
      ("a3", ("soft drink", 5)) ]
```

A `purchase` comprises a `sequence of items` modeled a list of items  where each item is a pair:

$\qquad (np,ac)$

describing a number of pieces $np$ (which is a non-negative integer) purchased of an article with code $ac$:

```fsharp
type numPieces = int   // np where np >= 0
type item      = numPieces * articleCode
type purchases = item list
```

An example of a purchase:

```fsharp
let purch1 = [ (3, "a2"); (1, "a1") ]
```

A bill comprises an information sequence `infos` for the individual item and the grand total `sum`, and this composite structure is modeled on a pair:

$\qquad [ (3,\space "a2");\space (1,\space "a1") ]$

A bill comprises an information sequence $infos$ for the individual items and the grand total $sum$, and this composite structure is modelled by a pair:

$\qquad (infos, sum)$

where each element in the list of $infos$ is a triple

$\qquad (np, aname. tprice)$

of the number of pieces $np$, and the name $aname$, and the total price $tprice$ of a purchase article:

```fsharp
type info    = numPieces * articleName * price
type infoseq = info list
type bill    = infoseq * price
```

The following is an example of a bil:

```fsharp
let bill1 = ([ (3, "herring", 12); (1, "cheese", 25) ], 37)
```

the function $makeBill$ computes a bill given a purchase and a register, it has the type:

```fsharp
val makeBill (purchase * register) -> bill
```

The exception $FindArticle$ is raised in the case where an article code of a purchase does not occur in a given register:


The list of definitions

| Interface definition:                                         |
|---------------------------------------------------------------|
| type articleCode = string                                     |
| type articleName = string                                     |
| type numPieces   = int                                        |
| type price       = int                                        |
| type register    = (articleCode * (articleName * price)) list |
| type item        = numPieces * articleCode                    |
| type purchases   = item list                                  |
| type info        = numPieces * articleName * price            |
| type infoseq     = info list                                  |
| type bill        = infoseq * price                            |
|                                                               |
| exception FindArticle                                         |
| val makeBill (purchase * register) -> bill                    |

### Programming

```fsharp

let rec findArticle = function
    | (ac, (ac', adesc) :: reg) ->
        if ac=ac' then adesc else findArticle(ac, reg)
    | _  -> raise FindArticleEx

// val findArticle: 'a * ('a * 'b) list -> 'b when 'a: equality
```

```fsharp
let rec makeBill = function
    | ([], _)               -> ([], 0)
    | ((np, ac) :: pur, reg) ->
        let (aname, aprice) = findArticle(ac, reg)
        let tprice   = np * aprice
        let (billtl, sumtl) = makeBill(pur, reg)
        ((np, aname, tprice) :: billtl, tprice + sumtl)

//  val makeBill:
//   (int * 'a) list * ('a * ('b * int)) list -> (int * 'b * int) list * int
//     when 'a: equality
```

### Testing

 Test cases                                

| Case | Function    | Branch                  | Remark             |
|------|-------------|-------------------------|--------------------|
| 1    | findArticle | -                       | Empty register     |
| 2    | findArticle | (ac, (ac', adesc)::reg) | Non-empty reg      |
|      |             | ac=ac'                  | found              |
| 3    | findArticle | (ac, (ac',adesc)::reg)  | Non-empty reg      |
|      |             | not ac=ac'              | not found          |
| 4    | makeBill    | ([], _)                 | Empty purchase     |
| 5    | makeBill    | ((np,ac)::pur,reg       | Non-empty purchase |

## B. Map colouring

When a `map` is `coloured` the `colouts` should be chosen to all the `neighbouring countries` get different colours.
The problem is to construct a program computing such `colouring`.
This problem will illustrate `functional decomposition` where the program is constructed by a collection of simple, but well-understood functions that can be composed to solve the problem.

A `country` is represented by its name as a $string$, whereas the `map` is represented `neighbour relation`
that is represented as a `list of pairs of countries` which have a common border.

```fsharp
type Country = string
type Border  = Country * Country
type Map     = Border list
```

The F# list of pairs:

```fsharp
let exMap : Map = [("a", "b"); ("c", "d"); ("d", "a")]
```

defines a `map` comprising four `countries` $a$, $b$, $c$, and $d$,
where the country $a$ has the neighbouring countries $b$ and $d$,
The country $b$ has the neighbouring country $a$ and so on.

A `colour` on a map is represented by a `list of countries` having the same `colour`,
and a `colouring` is described as a list of mutually disjoint `colours`.
The above countries may be coloured by the `colouring`:

```fsharp
type Colour = Country list
type Colouring = Colour list
```

The `counntries` of the example map may be coloured by the `colouring`:

$\qquad [["a"; \space "c"]; \space ["b"; \space "d"]]$

where this `colouring` has two colours $["a";"c"]$ and $["b"; "d"]$,
where countries $a$ and $c$ get one `colour` and countries $b$ and $d$ get another `colour`.

A Data model for map colouring problem:

| Meta symbol: Type | Definition            | Sample value            | 
|-------------------|-----------------------|-------------------------|
| c: Country        | string                | "a","b","c","d"         |
| m: Map            | (Country*Country list | [(a","b");              |
|                   |                       | ..("c","d"); ("d","a")] |
| col: Colour       | Country list          | ["a"; "c"]              |
| cols: Colouring   | Colour list           | [["a";"c"];["b";"d"]]   |

Our task is to declare a function:

$\qquad colMap:\space Map \space -> \space Colouring$

that can generate a `colouring` of a given `map`
We will express the function as a composition of simpler functions.

We will start with an empty `colouring` Then we will extend the actual colouring by adding one country at a time.

```fsharp
given exMap: [("a","b"); ("c","d"); ("d","a")]
"a" -> []                -> [["a"]]
"b" -> [["a"]]           -> [["a"];["b"]]
"c" -> [["a"];["b"]]     -> [["a";"c"];["b"]]
"d" -> [["a";"c"];["b"]] -> [["a";"c"];["b";"d"]]
```
We illustrate the operation on the `map` of four countries "a", "b", "c", and "d" with these steps:

1. The colouring containing no colours is the empty list.
2. The colour $["a"]$ cannot be `extended` by "b" because the countries "a" and "b" share borders. Hence, the `colouring` should be extended with $["b"]$
3. The colour $["a"]$ can be `extended` by "c" because "a" and "c" are not neighbours.
4. The colour $["a";"c"]$ can not be `extended` by "d" while the colour $["b"]$ can be extended by "d".

The algorithmic concepts are shown as:

* Test whether the `colour` can be extended by a `country` for a given `map`.
* Test whether the two `countries` are `neighbors` in a given `map`.
* Extend a `colouring` be a `country` for a given map

The types and meanings of the functions are:

```fsharp
 areNb: Map -> Country -> bool
```

which decides whether two countries are neighbors

```fsharp
 canBeExtBy: Map -> Colour -> bool
```
which decides whether a colour can be extended by a country

```fsharp
extColouring: Map -> Colouring -> Country -> Colouring
```
which extends a colouring by an extra country


```fsharp
countries: Map -> Country list
```
produces a list of countries in a map

```fsharp
colCntrs: Map -> Country list -> Colouring
```

Builds a colouring from a list of countries

Now to the function declarations:

* A predicate which determines whether two countries are neighbours in a given map.

```fsharp
let rec areNB m c1 c2 =
    isMember (c1, c2) m || isMember (c2, c1) m
```

* A predicate to determine for a given map whether a colour can be ex￾tended by a country

```fsharp
let rec canBeExtendBy m col c =
    match col with
    | []         -> true
    | c' :: col' -> not (areNB m c' c) && canBeExtendBy m col' c

canBeExtBy exMap ["c"] "a";;
val it : bool = true

canBeExtBy exMap ["a"; "c"] "b";;
val it : bool = false
```

* Our solution inserts the countries of a map one after the other into a colouring,
starting with the empty one. So we declare a function `extColoring` that for a given map extends a partial colouring by country

```fsharp
let rec extColouring m cols c =
    match cols with
    | []           -> [[c]]
    | col :: cols' ->
        if canBeExtendBy m col c
        then (c :: col) :: cols'
        else col :: extColouring m cols' c

extColouring exMap [] "a";;
val it : string list list = [["a"]]

extColouring exMap [["c"]] "a";;
val it : string list list = [["a"; "c"]]

extColouring exMap [["b"]] "a";;
val it : string list list = [["b"]; ["a"]]
```

* To complete our task we declare a function to extract a list of countries without
repeated elements from a map and a function to colour a list of countries given a map.

```fsharp
// Only add element if it's not already present.
let addElem x ys =
    if isMember x ys then ys else x::ys

// Add a pair of countries (border?) to a list if they aren't already their
let rec countries = function
    | []        -> []
    | (c1, c2) :: m -> addElem c1 (addElem c2 (countries m))

/// Colour a list of countries given a map
let rec colCntrs m = function
    | []   -> []
    | c::cs -> extColouring m (colCntrs m cs) c
```

// The function

```fsharp
/// Produces a colouring for a given map
let colMap map =
    colCntrs map (countries map)
```
