namespace Chapter01.Exercises

open System
open Xunit
open Swensen.Unquote

open Chapter01.Exercise_01

module Exercise_01 =

    [<Fact>]
    let ``test the g function``() =
        test <@ g 0 = 4 @>
        test <@ g 1 = 5 @>
        test <@ g -4 = 0 @>
        test <@ g 4 = 8 @>
