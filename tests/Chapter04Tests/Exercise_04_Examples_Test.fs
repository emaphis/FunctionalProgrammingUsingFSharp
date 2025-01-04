module Chapter04Tests.Exercise_04_Examples_Test

open Xunit
open Swensen.Unquote

open Chapter04.Exercise_04_Examples


[<Fact>]
let ``Test exercise_04 Examples length function function`` () =
    test <@ length' [] = 0 @>
    test <@ length' [1] = 1 @>
    test <@ length' [1;2] = 2 @>
    test <@ length' [1;2;3] = 3 @>


[<Fact>]
let ``Test exercise_04 Examples nth function`` () =
    test <@ nth ([1], 0) = 1 @>
    test <@ nth ([1; 2], 0) = 1 @>
    test <@ nth ([1; 2; 3], 2) = 3 @>  // book example
    raises<System.Exception> <@ nth ([1; 2; 3], 3) @>


[<Fact>]
let ``Test exercise_04 Examples take function`` () =
    test <@ take ([1], 0) = [] @>
    test <@ take ([1;2], 1) = [1] @>
    test <@ take ([1;2], 2) = [1; 2] @>
    test <@ take ([0;1;2;3;4;5;6], 4) = [0; 1; 2; 3] @>  // book example


[<Fact>]
let ``Test exercise_04 Examples drop function`` () =
    test <@ take ([1], 0) = [] @>
    test <@ drop ([], 0) = [] @>
    test <@ drop ([1;2;3], 0) = [1; 2; 3] @>
    test <@ drop ([1;2;3], 1) = [2; 3] @>
    test <@ drop ([1;2;3], 2) = [3] @>
    test <@ drop ([1;2;3], 3) = [] @>
    test <@ drop([0; 1; 2; 3; 4; 5; 6], 4) = [4; 5; 6] @>  // book example
