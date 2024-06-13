module Chapter03.Section_03_03_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter03.Section_03_03

[<Fact>]
let ``Test Example 3.3: Geometric vectors`` () =
    let a = (1.0, -2.0)
    let b = (3.0, 4.0)
    test <@ a +. b = (4.0, 2.0) @>
    test <@ a -. b = (-2.0, -6.0) @>
    test <@ -. a = (-1.0, 2.0) @>
    test <@ 2.0 *. a = (2.0, -4.0) @>
    test <@ 2.0 *. a -. b = (-1.0, -8.0) @>
    test <@  c &. a = 15.0 @>
    test <@  norm b = 5.0 @>
