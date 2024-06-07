module Chapter02.Exercise_02_09_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_09

[<Fact>]
let ``Test exercise 2_9 `f` function`` () =
    test <@ f(0, 0) = 0 @>
    test <@ f(1, 0) = 0 @>
    test <@ f(0, 1) = 1 @>
    test <@ f(1, 1) = 1 @>
    test <@ f(2, 1) = 2 @>
    test <@ f(3, 1) = 6 @>
    test <@ f(4, 1) = 24 @>
    test <@ f(5, 1) = 120 @>
    test <@ f(6, 1) = 720 @>
    test <@ f(7, 1) = 5040 @>
    test <@ f(8, 1) = 40320 @>
    test <@ f(1, 2) = 2 @>
    test <@ f(2, 1) = 2 @>
    test <@ f(2, 2) = 4 @>
    test <@ f(2, 3) = 6 @>
    test <@ f(2, 4) = 8 @>
    test <@ f(3 ,3) = 18 @>
    test <@ f(4, 3) = 72 @>
