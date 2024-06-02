namespace Chapter01.Exercises

open System
open Xunit
open Swensen.Unquote

open Chapter01.Exercise_05

module Exercise_05 =

    [<Fact>]
    let ``test the fibo function``() =
        test <@ f 0 = 0 @>
        test <@ f 1 = 1 @>
        test <@ f 2 = 1 @>
        test <@ f 3 = 2 @>
        test <@ f 4 = 3 @>
        test <@ f 5 = 5 @>
        test <@ f 6 = 8 @>
        test <@ f 7 = 13 @>
        test <@ f 8 = 21 @>
