module Chapter04Tests.Exercise_04_05_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_05

[<Fact>]
let ``Test Exercise 4.5 rmodd`` () =
   test <@ rmodd [] = [] @>
   test <@ rmodd [0] = [0] @>
   test <@ rmodd [0;1] = [0] @>
   test <@ rmodd [0;1;2] = [0;2] @>
   test <@ rmodd [0;1;2;3] = [0;2] @>
   test <@ rmodd [0;1;2;3;4] = [0;2;4] @>
   test <@ rmodd [0;1;2;3;4;5] = [0;2;4] @>
