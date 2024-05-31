namespace Chapter01

open System
open Xunit
open Swensen.Unquote

open Section04

module FactorialTests =

    [<Fact>]
    let ``test fact function``() =
        test <@ fact 0 = 1 @>
        test <@ fact 1 =   1 @>
        test <@ fact 2 =   2 @>
        test <@ fact 3 =   6 @>
        test <@ fact 4 =  24 @>
        test <@ fact 5 = 120 @>
        test <@ fact 6 = 720 @>
        test <@ fact 7 = 5040 @>
        test <@ fact 8 = 40320 @>
        test <@ fact 9 = 362880 @>
        test <@ fact 10 = 3628800 @>