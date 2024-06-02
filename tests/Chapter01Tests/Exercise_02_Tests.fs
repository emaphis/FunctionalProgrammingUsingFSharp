namespace Chapter01.Exercises

open System
open Xunit
open Swensen.Unquote

open Chapter01.Exercise_02

module Exercise_02 =

    [<Fact>]
    let ``test the h function``() =
        test <@ h(0.0, 0.0) = 0.0 @>
        test <@ h(3.0, 4.0) = 5.0 @>
        test <@ h(6.0, 8.0) = 10.0 @>
        test <@ h(8.0, 15.0) = 17.0 @>
