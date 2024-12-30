module Chapter04Tests.CashRegister_04_06_Test

open Xunit
open Swensen.Unquote

open Chapter04.CashRegister_04_06


[<Fact>]
let ``Test CashRegister 4.6 findArticle`` () =
    let register: Register =
        [("a1", ("cheese", 25));
         ("a2", ("herring", 4));
         ("a3", ("soft drink", 5))]
    let pur = [(3, "a2"); (1, "a1")]
    let bill = ([(3, "herring", 12); (1, "cheese", 25) ], 37)

    test <@ (findArticle "a3" register) = ("soft drink", 5)  @>
    raises<FindArticleEx> <@ (findArticle "a38" []) @>

    test <@ makeBill register [] = ([], 0) @>
    test <@ makeBill register pur = bill @>


