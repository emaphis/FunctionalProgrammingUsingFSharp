module Chapter04.CashRegister_04_06

(* Cash Register problem from section 4.5 *)

// Data definitions

// definitions describing an article
type ArticleCode = string
type ArticleName = string
type Price = int  // pr where pr >= 0

/// Associates article name and article price with each article code
type Register = (ArticleCode * (ArticleName * Price)) list

/// Number of pieces per item purchased
type NoPieces = int   // np where np >= 0

/// item purchased
type Item = NoPieces * ArticleCode

/// Register of purchases
type Purchases = Item list

/// The info for each line of a bill
type Info = NoPieces * ArticleName * Price

/// The list of infos making up a bill
type Infoseq = Info list


/// the info sequence and the total price
type Bill = Infoseq * Price


// Functions

/// Raised in the case where article code of a purchase is not found in the register
exception FindArticleEx

/// Given the article code and register returns the article pair. 
let rec findArticle ac = function
    | (ac', adesc) :: _ when ac=ac' -> adesc
    | _ :: reg                      -> findArticle ac reg
    | _                             -> raise FindArticleEx

//val findArticle: ac: 'a -> _arg1: ('a * 'b) list -> 'b when 'a: equality

/// Takes a list of items purchased and a register and returns a bill
let rec makeBill reg = function
    | []                -> ([], 0)
    | (np, ac) :: pur ->
        let aname, aprice  = findArticle ac reg
        let tprice         = np * aprice
        let billtl, sumtl  = makeBill reg pur
        (np, aname, tprice) :: billtl, tprice + sumtl

//val makeBill:
//  reg: ('a * ('b * int)) list ->
//    _arg1: (int * 'a) list -> (int * 'b * int) list * int when 'a: equality


(*
// Examples

// Example register
let register: Register =
    [("a1", ("cheese", 25));
     ("a2", ("herring", 4));
     ("a3", ("soft drink", 5))]

// Example of a purchase
let pur = [(3, "a2"); (1, "a1")]

// Example bill
let bill = ([(3, "herring", 12); (1, "cheese", 25) ], 37)


// tests

//let art0 :  (ArticleName * Price) = findArticle "a38" []
//  FSI_0013+FindArticleEx: FindArticleEx

let art1 = findArticle "a3" register = ("soft drink", 5)

let bill1 = makeBill register [] = ([], 0)

let bill2 = makeBill register pur = bill

*)
