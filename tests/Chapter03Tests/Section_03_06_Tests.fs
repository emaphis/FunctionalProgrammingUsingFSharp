module Chapter03.Section_03_06_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter03.QuadraticEquation

[<Fact>]
let ``Test Example 3.6: Quadratic Equation solve`` () =
   test <@ solve(2.0, 8.0, 8.0) = (-2.0, -2.0) @>
   test <@ solve(1.0, 1.0, -2.0) = (1.0, -2.0) @>
   test <@ solve(5.0 , 6.0, 1.0) = (-0.2, -1.0) @>
   raises<System.Exception> <@ solve(1.0, 0.0, 1.0) @>
   raises<System.Exception> <@ solve(0.0, 1.0, 1.0) @>
 
