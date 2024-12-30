# 4.6 Examples. A model-based approach

Problem solving II

## Cash Register.

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
To achieve this we name the important concept of the problem and we associate types with those names.

Article code and article name are central concepts in the formulation. 

```fsharp
type articleCode = string;;
type articleName = string;;
```

We chose to represent these with strings

The `register` associates the `article name` and `article price` with each `article code`, ane we model a `register by a list of pairs.

Each pair has the form

$\qquad (ac, (aname, aprice))$

where $ad$ is an article code, $aname$ is the article name and $aprice$ is the article price.  We chose (non-negative) integers to represent prices.

```fsharp
type price = int;;  // pr where pr >= 0
```

We get the following type for a `register`.

```fsharp
type register = (articleCode * (articleName * price)) list
```

The following is an example of a register:

```fsharp
let reg1 =
    [ ("a1", ("cheese", 25));
      ("a2", ("herring", 4));
      ("a3", ("soft drink", 5)) ]
```

A `purchase` comprises a `sequence of items` modeled a a list of items  where each item is a pair:

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

the function $makeBill$ computes a bill given a prerchase and a register, it has the type:

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
| 3    | findArticle | (ac, (ac',adesc)::reg)  | Non-emty reg       |
|      |             | not ac=ac'              | not founc          |
| 4    | makeBill    | ([], _)                 | Empty purchase     |
| 5    | makeBill    | ((np,ac)::pur,reg       | Non-empty purchase |







