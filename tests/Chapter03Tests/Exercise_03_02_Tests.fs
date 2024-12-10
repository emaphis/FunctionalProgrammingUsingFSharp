module Chapter03.Exercise_03_02_Tests

open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_02

[<Fact>]
let ``Test Exercise 3.2: normalize`` () =
   test <@ normalize (0, 0, 11) = (0, 0, 11)  @>
   test <@ normalize (0, 0, 12) = (0, 1, 0) @>
   test <@ normalize (0, 0, 13) = (0, 1, 1) @>
   test <@ normalize (0, 0, 24) = (0, 2, 0) @>
   test <@ normalize (0, 19, 0) = (0, 19, 0) @>
   test <@ normalize (0, 20, 0) = (1, 0, 0) @>
   test <@ normalize (0, 21, 0) = (1, 1, 0) @>
   test <@ normalize (1, 19, 12) = (2, 0, 0) @>
   test <@ normalize (0, 0, 24) = (0, 2, 0) @>
   test <@ normalize (0, 38,24) = (2, 0, 0) @>
   

