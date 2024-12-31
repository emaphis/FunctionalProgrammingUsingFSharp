module Exercise_04_01_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_01


[<Fact>]
let ``Test Exercose 4.1 upto`` () =

    test <@ upto 0 = [] @>
    test <@ upto 1 = [1] @>
    test <@ upto 10 = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] @>
