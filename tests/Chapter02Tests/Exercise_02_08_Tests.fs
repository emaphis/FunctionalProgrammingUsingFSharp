module Chapter02.Exercise_02_08_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_08

[<Fact>]
let ``Test exercise 2_8 bin (coeficient) function`` () =
    test <@ bin(0,0) = 1 @>
    test <@ bin(1,0) = 1 @>
    test <@ bin(1,1) = 1 @>
    test <@ bin(2,0) = 1 @>
    test <@ bin(2,1) = 2 @>
    test <@ bin(2,2) = 1 @>
    test <@ bin(3,0) = 1 @>
    test <@ bin(3,1) = 3 @>
    test <@ bin(3,2) = 3 @>
    test <@ bin(4,0) = 1 @>
    test <@ bin(4,1) = 4 @>
    test <@ bin(4,2) = 6 @>
    test <@ bin(4,3) = 4 @>
    test <@ bin(5,0) = 1 @>
    test <@ bin(5,1) = 5 @>
    test <@ bin(5,2) = 10 @>
    test <@ bin(5,3) = 10 @>
    test <@ bin(5,4) = 5 @>
    test <@ bin(5,5) = 1 @>