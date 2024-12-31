module Exercise_04_02_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_02


[<Fact>]
let ``Test Exercise 4.2 downto1`` () =

    test <@ downto1 0 = [] @>
    test <@ downto1 1 = [1] @>
    test <@ downto1 5 = [5; 4; 3; 2; 1] @>
