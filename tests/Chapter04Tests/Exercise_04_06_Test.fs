module Chapter04Tests.Exercise_04_06_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_06

[<Fact>]
let ``Test Exercise 4.6 rmeven`` () =
    test <@ rmeven [] = [] @>
    test <@ rmeven [0;1] = [1] @>
    test <@ rmeven [0;1;2] = [1] @>
    test <@ rmeven [0;1;2;3] = [1;3] @>
    test <@ rmeven [0;1;2;3;4] = [1;3] @>
    test <@ rmeven [0;1;2;3;4;5] = [1;3;5] @>

