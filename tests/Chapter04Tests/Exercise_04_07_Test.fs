module Exercise_04_07_Test


open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_07

[<Fact>]
let ``Test Exercise 4.7 multiplicity`` () =
    test <@ multiplicity 1 [] = 0 @>
    test <@ multiplicity 1 [1] = 1 @>
    test <@ multiplicity 1 [1;2;3;4] = 1 @>
    test <@ multiplicity 1 [1;2;1;4] = 2 @>
    test <@ multiplicity 1 [1;1;1;1] = 4 @>
    test <@ multiplicity 'a' ['b';'c';'a';'e';'a'] = 2 @>
