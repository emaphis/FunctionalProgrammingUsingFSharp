namespace Chapter01.Exercises

open System
open Xunit
open Swensen.Unquote

open Chapter01.Exercise_04

module Exercise_04 =

    [<Fact>]
    let ``test the f function``() =
        test <@ f 0 = 0 @>
        test <@ f 1 = 1 @>
        test <@ f 2 = 3 @>
        test <@ f 4 = 10 @>
        test <@ f 5 = 15 @>
        test <@ f 10 = 55 @>
        test <@ f 100 = 5050 @>
