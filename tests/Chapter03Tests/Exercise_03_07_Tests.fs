module Chapter03Tests.Exercise_03_07_Test

open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_07


[<Fact>]
let ``Test Exercise 3.5 Quadratic solution`` () =
   test <@ area (Triangle(3.0,4.0,5.0)) = 6.0 @>
   Assert.Equal(4.523893421, (area (Circle 1.2)), 0.000001)
   raises<exn> <@ area (Triangle(3.0,4.0,7.5)) @>
   test <@ area (Triangle (3.0, 4.0, 5.0)) = 6.0 @>
