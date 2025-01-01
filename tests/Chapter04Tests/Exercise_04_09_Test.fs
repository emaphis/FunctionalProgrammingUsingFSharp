module Chapter04Tests.Exercise_04_09_Test


open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_09

[<Fact>]
let ``Test Exercise 4.9 length`` () =
    test <@ length [] = 0 @>
    test <@ length [0] = 1 @>
    test <@ length [0;1;2] = 3 @>


[<Fact>]
let ``Test Exercise 4.9 zip`` () =
    test <@ zip [] [] = [] @>
    test <@ zip ["x0"] ["y0"] = [("x0", "y0")] @>
    test <@ zip ["x0"; "x1"] ["y0"; "y1"] =  [("x0", "y0"); ("x1", "y1")] @>
    test <@ zip [0; 2; 4] [1; 3; 5] = [(0, 1); (2, 3); (4, 5)] @>
