module Chapter04.Exercise_04_08_Test


open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_08

[<Fact>]
let ``Test Exercise 4.8 split`` () =
    test <@ split [] = ([],[]) @>
    test <@ split [0] = ([0], []) @>
    test <@ split [0;1] = ([0], [1]) @>
    test <@ split [0;1;2] = ([0; 2], [1]) @>
    test <@ split [0;1;2;3] = ([0; 2], [1; 3]) @>
    test <@ split [0;1;2;3;4] = ([0; 2; 4], [1; 3]) @>
    test <@ split ['a';'b';'c'] = (['a';'c'], ['b']) @>
