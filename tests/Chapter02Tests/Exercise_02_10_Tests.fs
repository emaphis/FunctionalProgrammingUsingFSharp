module Chapter02.Exercise_02_10_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_10

let rec fact = function
    | 0 -> 1
    | n -> n * fact(n-1)

// [<Fact>]
// let ``Test for overflow due to eagaer evaluation``() =
//     raises<StackOverflowException> <@ testIt(false, (fact -1)) @>

[<Fact>]
let ``Test exercise 2_10 testIt function`` () =
    test <@ testIt(false, (5 - 4)) = 0 @>
    test <@ testIt(true, (5 - 4)) = 1 @>
