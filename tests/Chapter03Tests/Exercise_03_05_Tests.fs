module Chapter03Tests.Exercise_03_05_Test

open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_05


[<Fact>]
let ``Test Exercise 3.5 Quadratic solution`` () =
   test <@ solve (1.0, 0.0, 1.0) = NoRoot @>
   test <@ solve (0.0, 5., -3.0) = NoRoot @>
   test <@ solve (2.0, 8.0, 8.0) = OneRoot -2.0 @>
   test <@ solve (1.0, 1.0, -2.0) = TwoRoots (1.0, -2.0) @>
   test <@ solve (1.0, 0.0, -25.0)  = TwoRoots (5.0, -5.0) @>
