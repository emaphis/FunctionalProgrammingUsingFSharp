module Exercise_04_03_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_03


[<Fact>]
let ``Test Exercise 4.3 evenN`` () =
    test <@ evenN 0 = [] @>
    test <@ evenN 1 = [2] @>
    test <@ evenN 3 = [2; 4; 6] @>
    test <@ evenN 5 = [2; 4; 6; 8; 10] @>
