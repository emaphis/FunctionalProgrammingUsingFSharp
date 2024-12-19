module Chapter03Tests.Exercise_03_04_Test

open Xunit
open Swensen.Unquote

open Chaper03.Exercise03_04


[<Fact>]
let ``Test Exercise 3.4 reflectX`` () =
   test <@ reflectX (0.0, 0.0) = (0.0, 0.0) @>
   test <@ reflectX (1.0, 1.0) = (-1.0, -1.0) @>
   test <@ reflectX (3.0, 4.0) = (-3.0, -4.0) @>


[<Fact>]
let ``Test Exercise 3.4 reflectY`` () =
   test <@ reflectY (0.0, 0.0) = (0.0, 0.0) @>
   test <@ reflectY (1.0, 1.0) = (-1.0, 1.0) @>
   test <@ reflectY (3.0, 4.0) = (-3.0, 4.0) @>


[<Fact>]
let ``Test Exercise 3.4 getString`` () =
   test <@ getString (0.0, 0.0) = "y = 0.00x + 0.00" @>
   test <@ getString (1.0, 1.0) = "y = 1.00x + 1.00" @>
   test <@ getString (3.0, 4.0) = "y = 3.00x + 4.00" @>
