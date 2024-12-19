module Chapter03Tests.Exercise_03_03_Test

open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_03


[<Fact>]
let ``Test Exercise 3.3: (+.)`` () =
   test <@ (3.0, 2.0) +. (0.0, 0.0) = (3.0, 2.0) @>
   test <@ (3.0, 2.0) +. (1.0, 7.0) = (4.0, 9.0) @>
   test <@ (3.0, 5.0) +. (4.0, -3.0) = (7.0, 2.0) @>

[<Fact>]
let ``Test Exercise 3.3: (-.)`` () =
   test <@ (3.0, 2.0) -. (0.0, 0.0) = (3.0, 2.0) @>
   test <@ (3.0, 2.0) -. (1.0, 7.0) = (2.0, -5.0) @>
   test <@ (3.0, 5.0) -. (4.0, -3.0) = (-1.0, 8.0) @>

[<Fact>]
let ``Test Exercise 3.3: (*.)`` () =
   test <@ (1.0, 1.0) *. (1.0, 1.0) = (0.0, 2.0) @>
   test <@ (0.0, 1.0) *. (0.0, 1.0) = (-1.0, 0.0) @>
   test <@ (3.0, 2.0) *. (1.0, 7.0) = (-11.0, 23.0) @>

[<Fact>]
let ``Test Exercise 3.3: (/.)`` () =
   test <@ (1.0, 1.0) /. (2.0, 2.0) = (0.5, 0.) @>
