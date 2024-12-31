module Chapter04Tests.Exercise_04_04_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_04

[<Fact>]
let ``Test Exercise 4.4: altsum`` () =
    test <@ altsum [2;-1; 3] = 6 @>  // example from the book.
    test <@ altsum [] = 0 @>
    test <@ altsum [0] = 0 @>
    test <@ altsum [1; 1] = 0 @>
    test <@ altsum [1; 2] = -1 @>
    test <@ altsum [1; 2; 3] = 2 @>
    test <@ altsum [1; 2; 3; 4; 5] = 3 @>
    test <@ altsum [1; 1; 1; 1; 1] = 1 @>
