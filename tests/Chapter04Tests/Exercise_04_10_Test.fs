module Chapter04Tests.Exercise_04_10_Test



open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_10

[<Fact>]
let ``Test Exercise 4.9 prefix`` () =
    test <@ prefix [] []  = true @>
    test <@ prefix [] [1] = true @>
    test <@ prefix [1] [] = false @>
    test <@ prefix [1] [1] = true @>
    test <@ prefix [1] [1;2] = true @>
    test <@ prefix [1;2] [1] = false @>
    test <@ prefix [1;2;3;4] [1;2;3;4;5;6] = true @>
