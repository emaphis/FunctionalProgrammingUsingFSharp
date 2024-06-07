module Chapter02.Exercise_02_06_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_06

[<Fact>]
let ``Test exercise_02_06 notDivisable function function`` () =
    test <@ notDivisible(2,3) = true @>
    test <@ notDivisible(3,9) = false @>
    test <@ notDivisible(2,4) = false @>
    test <@ notDivisible(3, 7) = true @>
