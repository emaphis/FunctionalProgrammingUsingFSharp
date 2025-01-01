module Chapter04Tests.Exercise_04_05_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_05

[<Fact>]
let ``Test Exercise 4.5 rmodd`` () =
   test <@ rmodd [] = [] @>
   test <@ rmodd [2] = [2] @>
   test <@ rmodd [1;2;3] = [2] @>
   test <@ rmodd [1;2;3;4] = [2;4] @>
   test <@ rmodd [8;2;3;4] = [8;2;4] @>
